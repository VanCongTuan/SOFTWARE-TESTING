from app.models import Category, Product

def load_categories():
    return Category.query.all()


