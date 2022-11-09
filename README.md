Как пушить в 1 раз <br>
<br>
git init <br>
git add . <br>
git rm --cached Core/App.Config <br>
git rm --cached School4Children/App.config <br>
git status (тут ниче писать не надо, но должно высветиться красным текстом 2 файлика, остальное зелёным) <br>
git remote add origin (тут сслка) <br>
git commit -m "(название коммита)" <br>
git push -u origin (название ветки) <br>
<br>
// Вообще я уже запушил первый, так что это вам только для справки <br>
<br>
Как пушить после 1 раза
<br>
git add . <br>
git rm --cached Core/App.Config <br>
git rm --cached School4Children/App.config <br>
git status (тут ниче писать не надо, но должно высветиться красным текстом 2 файлика, остальное зелёным) <br>
git commit -m "(название коммита)" <br>
git push -u origin (название ветки) <br>
<br>
<br>
Для создания ветки <br>
git branch (Название ветки) <br>
<br>
Узнать текущую ветку <br>
git branch <br>
<br>
Переключиться на существующую ветку <br>
git checkout (название ветки) <br>
<br>
Создать ветку и тут же на неё переключиться <br>
Переключиться на существующую ветку <br>
git checkout -b (название ветки) <br>
<br>
Первый раз скачать проект с гита <br>
git clone (тут ссылка) <br>
<br>
Получить текущую версию проекта (когда он у вас уже есть) <br>
git fetch <br>
