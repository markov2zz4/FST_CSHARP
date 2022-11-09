#include <iostream>
#include <exception>

using namespace std;

class Queue {
public:
	Queue(const int queue_size) {
		
		index = -1;
		size = queue_size;
		
		queue = new int[size] {0};
	}
	

	void Print() {
		for (int i = 0; i < index+1; i++)
			cout << queue[i] << " ";
		cout << endl;
	}

	void push(int value) {
		if (isFull() == true)
			throw range_error("The queue is full");
		else {
			index++;
			queue[index] = value;
		}
	}

	void pop() {
		isEmpty() ? throw out_of_range("The queue is empty"): index--;
		cout << endl;
	}

private:
	int index;
	int size;
	int* queue;
	
	
	bool isFull() {
		return index+1 == size ? true : false;
	}
	bool isEmpty() {
		return index == 0 ? true : false;
	}


};

int main()
{
	Queue q(3);
	q.push(1);
	q.push(2);
	q.push(3);

	q.Print();

	q.pop();

	q.Print();

	q.pop();

	q.Print();

	q.push(1);
	q.push(2);

	q.Print();

	
}
