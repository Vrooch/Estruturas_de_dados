using System.Security.Cryptography.X509Certificates;

namespace my_array
{
    internal class SmartArray<T>
    {
        private T[] _content;
        private int _maxSize;
        public int MaxSize
        {
            get
            {
                return _maxSize;
            }
        }
        private int _currentSize;
        public int CurrentSize
        {
            get
            {
                return _currentSize;
            }
        }

        public SmartArray(int size)
        {
            if (size <= 0) throw new ArgumentException("Size should be greater than 0");

            _content = new T[size];
            _maxSize = size;
            _currentSize = 0;
        }

        public T this[int index]
        {
            get
            {
                if (index > GetCurrentPosition()) throw new IndexOutOfRangeException($"{index} is out of the current index range");
                if (index < 0) throw new IndexOutOfRangeException($"Index should be equals or greater than 0");
                
                return _content[index];
            }
            set
            {
                if (index > GetCurrentPosition()) throw new IndexOutOfRangeException($"{index} is out of the current index range");
                if (index < 0) throw new IndexOutOfRangeException($"Index should be equals or greater than 0");

                _content[index] = value;
            }
        }

        public void Insert(T value)
        {
            if(GetCurrentPosition() >= GetMaxPosition()) throw new CapacityException("It has already reached the max capacity of this instance");
            _content[_currentSize] = value;
            _currentSize++;
        }
        public IEnumerable<T> Iterate()
        {
            for(int i = 0; i<CurrentSize; i++)
            {
                yield return _content[i];
            }
        }

        public void Show()
        {
            Console.WriteLine(string.Join(", ", Iterate()));
        }

        public void RemoveLast()
        {
            /*
                Nao preciso de fato remover o ultimo valor.
                Apenas que garantir que ele nao seja mais exibido
                e atribuir o valor padroa (evitar vazamaneto de memeoria)
            */
            if(_currentSize == 0) throw new ArrayEmptyException("The current array is empty");
            _content[GetCurrentPosition()] = default!;
            _currentSize--;

        }

        public void RemoveByIndex(int index)
        {
            /*
                Nao preciso de fato remover o ultimo valor.
                Apenas garantir que ele nao seja mais exibido
                e atribuir o valor padrao (evitar vazamaneto de memeoria)
            */
            if(_currentSize == 0) throw new ArrayEmptyException("The current array is empty");
            if(GetCurrentPosition() < index) throw new IndexOutOfRangeException($"{index} is out of the current index range");
            if (index < 0) throw new IndexOutOfRangeException($"Index should be equals or greater than 0");

            for (int i = index; i < GetCurrentPosition(); i++)
            {
                _content[i] = _content[i+1];
            }

            _content[GetCurrentPosition()] = default!;
            _currentSize--;
        }

        public void RemoveByValue( T value)
        {
            /*
                Identifica a posicao pelo GetIndex
                Remove chamando o metofo RemoveByIndex
            */
            if(_currentSize == 0) throw new ArrayEmptyException("The current array is empty");

            int index = GetIndex(value);
            RemoveByIndex(index);
        }

        public int GetIndex( T value)
        {
            if(_currentSize == 0) throw new ArrayEmptyException("The current array is empty");
            for (int i = 0; i<_currentSize; i++)
            {
                if(EqualityComparer<T>.Default.Equals(_content[i], value)) return i;
            }
            throw new ArgumentException($"Value {value} not found");
        }

        public int GetMaxPosition()
        {
            return _maxSize -1;
        }
        public int GetCurrentPosition()
        {
            return _currentSize -1;
        }
    }
}