# Sat Recruitment

### This is a Rest API to Save, Get, Delete or Update User.

## Docker 
### We Need Docker To run this API, to create the conteiners run the next commnad into the console :

```
docker-compose -up
```

## ORM EF
## Use the next command into the console, to create the inicial SQL tables neededs:

```
add-migration inicial -Context SatContext
```

```
update-database -Context SatContext
```