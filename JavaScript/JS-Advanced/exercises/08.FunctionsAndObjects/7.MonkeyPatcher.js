function solution(commandName) {
    let balance = this.upvotes - this.downvotes;
    let totalVotes = this.upvotes + this.downvotes;

    let commands = {
        upvote: () => this.upvotes++,
        downvote: () => this.downvotes++,
        score: () => {
            let up = this.upvotes;
            let down = this.downvotes;

            if(totalVotes > 50) {
                let value = Math.ceil(Math.max(up, down) * 0.25);

                up += value;
                down += value;
            }

            return [up, down, balance, getRating.call(this)];

            function getRating() {
                let rating = '';

                if (this.upvotes  > (this.upvotes + this.downvotes) * 0.66) {
                    rating = 'hot';
                } else if (balance >= 0 && (this.upvotes > 100 || this.downvotes > 100)) {
                    rating = 'controversial';
                } else if (this.upvotes < this.downvotes) {
                    rating = 'unpopular';
                }

                if (totalVotes < 10 || rating === '') {
                    return 'new';
                }

                return rating;
            }
        }
    };

    return commands[commandName]();
}

let post = {
    id: '3',
    author: 'emil',
    content: 'wazaaaaa',
    upvotes: 100,
    downvotes: 100
};

solution.call(post, 'upvote');
solution.call(post, 'downvote');
console.log(solution.call(post, 'score')); // [127, 127, 0, 'controversial']

for (let i = 0; i < 50; i++) {
    solution.call(post, 'downvote');
}

console.log(solution.call(post, 'score')); // [139, 189, -50, 'unpopular']