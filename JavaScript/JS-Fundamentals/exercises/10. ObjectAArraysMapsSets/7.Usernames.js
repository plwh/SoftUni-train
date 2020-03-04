function solve(input) {
    let result = new Set();
    input.forEach(a => result.add(a));

    result = Array.from(result).sort(sortByLengthAndAlphabeticalOrder);

    console.log(result.join("\n"));

    function sortByLengthAndAlphabeticalOrder (a, b) {
        let itemALength = a.length;
        let itemBLength = b.length;

        // sort by length in ascending order
        if (itemALength < itemBLength) {
            return -1;
        } else if (itemALength > itemBLength) {
            return 1;
        }

        return a.localeCompare(b);
    }
}

solve(["Ashton",
    "Kutcher",
    "Ariel",
    "Lilly",
    "Keyden",
    "Aizen",
    "Billy",
    "Braston"]);