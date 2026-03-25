[![build and test](httpsgithub.comAOOP-Git-HappensHA2actionsworkflowsbuild-and-test.ymlbadge.svg)](httpsgithub.comAOOP-Git-HappensHA2actionsworkflowsbuild-and-test.yml)


# Functional Testing
## Borrowing [Passed]
The borrowing button was succesfully only avaible in the members catalog view and not able in the librarian view. Borrowing changed the book.json and was able to update the the MyLoans and CatalogView. After a book was borrowed others members were not able to access the book in catalog view.

-> I logged in with Bob and was sent to the catalog view. I was able to rent The hobbit and 1984. These were updated in the database (books.json) from "LoanedBy": "" to "LoanedBy": "Bob" 

-> the same result were shown for the Users Kevin and Dave

## Return [Passed]
Logged in as Bob. Then I clicked on "MyLoans" button. Bob had 1 book to return. When clicking red return button the book vanished from his "MyLoans". In the Database (book.json) the "LoanedBy": "bob" succesfully replaced his name with an empty space -> "LoanedBy": "". I also checked if the book appeared back in Catalogue which was succesfull.

After testing the returning I went back to Catalog and rented 2 books, which after clicking back in the MyLoans appeared and I was able to return both of them succesfully and replaced in the database empty

## Add Book [FAILED]
Add book is succsfully is only avaible for in the libarian view and not seen as members. The button is clickable and after being and adds a empty book. This can be added with the information from the book.json. If a book is added without any information its still visible. This normally should show an error sign that information is missing.

## Delete Book [Passed]
I could sucesfully delet books. After signing in as libarian I was able in the catalog view to delet the books and this also then removed all the text about this book from book.json

## Login [Passed]
This test was in 2 part
### Part 1 - Members
I logged in with all 3 members bob, dave & kevin. All of them were sucessfully showed the Catalogue View. All of them could only see their own personal rented books and could also only return their borrowed books.

### Part 2 - Librarian
I logged in with all 2 libs gru and lucy. Both were pointed to Active Loans at first and were able to see the active loans from all members (1984 - bob, test1 - bob, test2 - kevin, the hobit - dave). Both were able to see the all books in the Catalog and were able to add/delete/edit.

## Active Loan Tracking [Passed]

Logged in as a librarian (Gru/Lucy). I was able to see the active loans from all members simultaneously (e.g., 1984 - Bob, test1 - Bob, test2 - Kevin, The Hobbit - Dave).

## Search [Passed]
### Part 1 - Memebers
In the catalog view all 3 members were able to search after the author and the title and were able to show the according books. I was only able to search for the books that were not borrowed

-> I typed "te" and was showed in the catalog: "test1", "test2"

-> I typed "J.R.R" and was shown in the catalog "The hobit"

### Part 2 - Librarian
In the catalog view all 2 members were able to search after the author and the title and wer able to show the according books. I was able to search for all books (borrowed + not borrowed)

-> I typed "te" and was showed in the catalog: "test1", "test2"

-> I typed "J.R.R" and was shown in the catalog "The hobit"


## Data Persistence Test [Passed]
I verified that all changes made during the tests (borrowing books, returning books, adding/deleting books) were accurately saved to books.json. Furthermore, I completely closed and restarted the application, and verified that all previously borrowed books and catalog changes persisted correctly upon reboot.
