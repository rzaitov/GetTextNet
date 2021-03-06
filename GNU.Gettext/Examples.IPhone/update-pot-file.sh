# generate .pot file from source code (collect all localization keys)
mono ../../Bin/Release/GNU.Gettext.Xgettext.exe -D ./ -o Localization/Messages.pot

# merge uptodate keys to translate files
msgmerge --backup=none -U Localization/En.po Localization/Messages.pot
msgmerge --backup=none -U Localization/Ru.po Localization/Messages.pot
