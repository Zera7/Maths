import Foundation

var numbers: [Int] = []

func initNumbers() {
    for i in 1 ... 20000000 {
        numbers.append(i)
    }
}

func calculate() {
    var results: [Int] = []
    let dispatchGroup = DispatchGroup()
    let semaphore = DispatchSemaphore(value: ProcessInfo.processInfo.processorCount)
    
    initNumbers()
    
    for i in 1 ... 100 {
        DispatchQueue.global(qos: .userInitiated).async(group: dispatchGroup, execute: {
            semaphore.wait()
            let array = numbers.shuffled()
            print("array \(i) ready")
            
            var result = 1
            var maxValue: Int = array[0]
            for a in 1 ... array.count - 1 {
                if maxValue < array[a] {
                    maxValue = array[a]
                    result += 1
                }
            }
            results.append(result)
            print("calculate \(i) complete")
            semaphore.signal()
        })
    }

    dispatchGroup.wait()
    
    print(results)
}

calculate()
