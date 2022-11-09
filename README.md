Как пушить в 1 раз

git init
git add .
git rm --cached Core/App.Config
git rm --cached School4Children/App.config
git status (тут ниче писать не надо, но должно высветиться красным текстом 2 файлика, остальное зелёным)
git remote add origin (тут сслка)
git commit -m "(название коммита)"
git push -u origin (название ветки)

Как пушить после 1 раза

git add .
git rm --cached Core/App.Config
git rm --cached School4Children/App.config
git status (тут ниче писать не надо, но должно высветиться красным текстом 2 файлика, остальное зелёным)
git commit -m "(название коммита)"
git push -u origin (название ветки)


Для создания ветки
git branch (Название ветки)

Узнать текущую ветку
git branch

Переключиться на существующую ветку
git checkout (название ветки)

Создать ветку и тут же на неё переключиться
Переключиться на существующую ветку
git checkout -b (название ветки)