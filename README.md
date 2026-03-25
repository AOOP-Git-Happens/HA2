[![build and test](httpsgithub.comAOOP-Git-HappensHA2actionsworkflowsbuild-and-test.ymlbadge.svg)](httpsgithub.comAOOP-Git-HappensHA2actionsworkflowsbuild-and-test.yml)


# Functional Testing
## Borrowing [Passed]
The borrowing button was only succesfully avaible in the Member Catalog and not in the Librarian Catalog. Borrowing changed the book.json and was able to update the MyLoans and CatalogView. After a book was borrowed, other members were not able to access the book in member catalog.

-> We logged in with Bob credetentials and were redirected to the Member Catalog, where were able to rent The hobbit and 1984. These books were updated in the database (books.json) from "LoanedBy": "" to "LoanedBy": "Bob".

-> Same worked for the members Kevin and Dave.

## Return [Passed]
While logged in as Bob, we clicked on "MyLoans" button. Bob had 1 book to return. When clicking red return button, the book vanished from "MyLoans" page. In the Database (book.json) the "LoanedBy": "Bob" succesfully replaced the name with an empty space -> "LoanedBy": "". Book was also succesfully returned to Member Catalog. 

After testing the return process, we went back to the Member Catalog and rented two books. After navigating back to MyLoans, both books appeared, and we were able to return them successfully. The database was then updated, marking them as available (empty).

## Add Book [Passed]
Book addition is only avaliable in Librarian Catalog, but the result of new book added can be seen in both: Librarian and Member Catalogs. 

## Delete Book [Passed]
Books can be could successfully deleted. After signing in as Libarian, we were able to delete the books from Catalog and it also emptied book.json. 

## Active Loan Tracking [Passed]

When Logged in as a librarian (Gru/Lucy), we were able to see the active loans from all members simultaneously (e.g., 1984 - Bob and test1 - Bob, test2 - Kevin, The Hobbit - Dave).

## Login [Passed]
This test was passed in 2 parts.
### Part 1 - Members
We logged in with all 3 members, such as Bob, Dave & Kevin. All of them successfully landed on the Member Catalog. All could only see their own personal rented books and could only return their borrowed books.

### Part 2 - Librarian
We logged in with all 2 librarians: Gru and Lucy. Both were pointed to Active Loans at first and were able to see the active loans from all members (1984 and test1 - bob, test2 - Kevin, The Hobbit - Dave). Both were able to see all books in the Librarian Catalog and were able to add/delete/edit specific books.

## Search [Passed]
Both Members and the Librarian were able to search the catalog by author and title, and the correct books were displayed based on the input.
- When typing “te”, the catalog returned: “test1” and “test2”
- When typing “J.R.R”, the catalog returned: “The Hobbit”

The key difference between roles is:
- Members could only search for and view books that were not borrowed
- The Librarian could search for and view all books (both borrowed and not borrowed)


## Data Persistence Test [Passed]
We verified that all changes made during the tests (borrowing books, returning books, adding/deleting books) were accurately saved to books.json. Furthermore, we completely closed and restarted the application, and verified that all previously borrowed books and catalog changes persisted correctly upon reboot.
