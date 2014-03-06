using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace MartEdit
{
    public partial class Form1 : Form
    {
        int[,] data = new int[80, 20];
        string[] filepaths = new string[80];
        bool filling = true;
        MemoryStream bin = new MemoryStream(0);

        public Form1()
        {
            InitializeComponent(); 
            InitializeFields();
            B_Save.Enabled = false;
            B_List.Enabled = false;
        }

        private void InitializeFields()
        {
            var item_list = new[] {
                    new { Text = "", Value = 0 },
                    new { Text = "Absorb Bulb", Value = 545 },
                    new { Text = "Adamant Orb", Value = 135 },
                    new { Text = "Aguav Berry", Value = 162 },
                    new { Text = "Air Balloon", Value = 541 },
                    new { Text = "Amulet Coin", Value = 223 },
                    new { Text = "Antidote", Value = 18 },
                    new { Text = "Apicot Berry", Value = 205 },
                    new { Text = "Armor Fossil", Value = 104 },
                    new { Text = "Aspear Berry", Value = 153 },
                    new { Text = "Awakening", Value = 21 },
                    new { Text = "Babiri Berry", Value = 199 },
                    new { Text = "BalmMushroom", Value = 580 },
                    new { Text = "Belue Berry", Value = 183 },
                    new { Text = "Berry Juice", Value = 43 },
                    new { Text = "Big Mushroom", Value = 87 },
                    new { Text = "Big Nugget", Value = 581 },
                    new { Text = "Big Pearl", Value = 89 },
                    new { Text = "Big Root", Value = 296 },
                    new { Text = "Binding Band", Value = 544 },
                    new { Text = "Black Belt", Value = 241 },
                    new { Text = "Black Flute", Value = 68 },
                    new { Text = "Black Sludge", Value = 281 },
                    new { Text = "BlackGlasses", Value = 240 },
                    new { Text = "Blue Flute", Value = 65 },
                    new { Text = "Blue Scarf", Value = 261 },
                    new { Text = "Blue Shard", Value = 73 },
                    new { Text = "Bluk Berry", Value = 165 },
                    new { Text = "BridgeMail D", Value = 145 },
                    new { Text = "BridgeMail M", Value = 148 },
                    new { Text = "BridgeMail S", Value = 144 },
                    new { Text = "BridgeMail T", Value = 146 },
                    new { Text = "BridgeMail V", Value = 147 },
                    new { Text = "BrightPowder", Value = 213 },
                    new { Text = "Bug Gem", Value = 558 },
                    new { Text = "Burn Drive", Value = 118 },
                    new { Text = "Burn Heal", Value = 19 },
                    new { Text = "Calcium", Value = 49 },
                    new { Text = "Carbos", Value = 48 },
                    new { Text = "Casteliacone", Value = 591 },
                    new { Text = "Cell Battery", Value = 546 },
                    new { Text = "Charcoal", Value = 249 },
                    new { Text = "Charti Berry", Value = 195 },
                    new { Text = "Cheri Berry", Value = 149 },
                    new { Text = "Cherish Ball", Value = 16 },
                    new { Text = "Chesto Berry", Value = 150 },
                    new { Text = "Chilan Berry", Value = 200 },
                    new { Text = "Chill Drive", Value = 119 },
                    new { Text = "Choice Band", Value = 220 },
                    new { Text = "Choice Scarf", Value = 287 },
                    new { Text = "Choice Specs", Value = 297 },
                    new { Text = "Chople Berry", Value = 189 },
                    new { Text = "Claw Fossil", Value = 100 },
                    new { Text = "Cleanse Tag", Value = 224 },
                    new { Text = "Clever Wing", Value = 569 },
                    new { Text = "Coba Berry", Value = 192 },
                    new { Text = "Colbur Berry", Value = 198 },
                    new { Text = "Comet Shard", Value = 583 },
                    new { Text = "Cornn Berry", Value = 175 },
                    new { Text = "Cover Fossil", Value = 572 },
                    new { Text = "Custap Berry", Value = 210 },
                    new { Text = "Damp Mulch", Value = 96 },
                    new { Text = "Damp Rock", Value = 285 },
                    new { Text = "Dark Gem", Value = 562 },
                    new { Text = "Dawn Stone", Value = 109 },
                    new { Text = "DeepSeaScale", Value = 227 },
                    new { Text = "DeepSeaTooth", Value = 226 },
                    new { Text = "Destiny Knot", Value = 280 },
                    new { Text = "Dire Hit", Value = 56 },
                    new { Text = "Dive Ball", Value = 7 },
                    new { Text = "Dome Fossil", Value = 102 },
                    new { Text = "Douse Drive", Value = 116 },
                    new { Text = "Draco Plate", Value = 311 },
                    new { Text = "Dragon Fang", Value = 250 },
                    new { Text = "Dragon Gem", Value = 561 },
                    new { Text = "Dragon Scale", Value = 235 },
                    new { Text = "Dread Plate", Value = 312 },
                    new { Text = "Dream Ball", Value = 576 },
                    new { Text = "Dubious Disc", Value = 324 },
                    new { Text = "Durin Berry", Value = 182 },
                    new { Text = "Dusk Ball", Value = 13 },
                    new { Text = "Dusk Stone", Value = 108 },
                    new { Text = "Earth Plate", Value = 305 },
                    new { Text = "Eject Button", Value = 547 },
                    new { Text = "Electirizer", Value = 322 },
                    new { Text = "Electric Gem", Value = 550 },
                    new { Text = "Elixir", Value = 40 },
                    new { Text = "Energy Root", Value = 35 },
                    new { Text = "EnergyPowder", Value = 34 },
                    new { Text = "Enigma Berry", Value = 208 },
                    new { Text = "Escape Rope", Value = 78 },
                    new { Text = "Ether", Value = 38 },
                    new { Text = "Everstone", Value = 229 },
                    new { Text = "Eviolite", Value = 538 },
                    new { Text = "Exp. Share", Value = 216 },
                    new { Text = "Expert Belt", Value = 268 },
                    new { Text = "Fast Ball", Value = 492 },
                    new { Text = "Favored Mail", Value = 138 },
                    new { Text = "Fighting Gem", Value = 553 },
                    new { Text = "Figy Berry", Value = 159 },
                    new { Text = "Fire Gem", Value = 548 },
                    new { Text = "Fire Stone", Value = 82 },
                    new { Text = "Fist Plate", Value = 303 },
                    new { Text = "Flame Orb", Value = 273 },
                    new { Text = "Flame Plate", Value = 298 },
                    new { Text = "Float Stone", Value = 539 },
                    new { Text = "Fluffy Tail", Value = 64 },
                    new { Text = "Flying Gem", Value = 556 },
                    new { Text = "Focus Band", Value = 230 },
                    new { Text = "Focus Sash", Value = 275 },
                    new { Text = "Fresh Water", Value = 30 },
                    new { Text = "Friend Ball", Value = 497 },
                    new { Text = "Full Heal", Value = 27 },
                    new { Text = "Full Incense", Value = 316 },
                    new { Text = "Full Restore", Value = 23 },
                    new { Text = "Ganlon Berry", Value = 202 },
                    new { Text = "GB Sounds", Value = 502 },
                    new { Text = "Genius Wing", Value = 568 },
                    new { Text = "Ghost Gem", Value = 560 },
                    new { Text = "Gooey Mulch", Value = 98 },
                    new { Text = "Grass Gem", Value = 551 },
                    new { Text = "Great Ball", Value = 3 },
                    new { Text = "Green Scarf", Value = 263 },
                    new { Text = "Green Shard", Value = 75 },
                    new { Text = "Greet Mail", Value = 137 },
                    new { Text = "Grepa Berry", Value = 173 },
                    new { Text = "Grip Claw", Value = 286 },
                    new { Text = "Griseous Orb", Value = 112 },
                    new { Text = "Ground Gem", Value = 555 },
                    new { Text = "Growth Mulch", Value = 95 },
                    new { Text = "Guard Spec.", Value = 55 },
                    new { Text = "Haban Berry", Value = 197 },
                    new { Text = "Hard Stone", Value = 238 },
                    new { Text = "Heal Ball", Value = 14 },
                    new { Text = "Heal Powder", Value = 36 },
                    new { Text = "Health Wing", Value = 565 },
                    new { Text = "Heart Scale", Value = 93 },
                    new { Text = "Heat Rock", Value = 284 },
                    new { Text = "Heavy Ball", Value = 495 },
                    new { Text = "Helix Fossil", Value = 101 },
                    new { Text = "HM01", Value = 420 },
                    new { Text = "HM02", Value = 421 },
                    new { Text = "HM03", Value = 422 },
                    new { Text = "HM04", Value = 423 },
                    new { Text = "HM05", Value = 424 },
                    new { Text = "HM06", Value = 425 },
                    new { Text = "Hondew Berry", Value = 172 },
                    new { Text = "Honey", Value = 94 },
                    new { Text = "HP Up", Value = 45 },
                    new { Text = "Hyper Potion", Value = 25 },
                    new { Text = "Iapapa Berry", Value = 163 },
                    new { Text = "Ice Gem", Value = 552 },
                    new { Text = "Ice Heal", Value = 20 },
                    new { Text = "Icicle Plate", Value = 302 },
                    new { Text = "Icy Rock", Value = 282 },
                    new { Text = "Inquiry Mail", Value = 141 },
                    new { Text = "Insect Plate", Value = 308 },
                    new { Text = "Iron", Value = 47 },
                    new { Text = "Iron Ball", Value = 278 },
                    new { Text = "Iron Plate", Value = 313 },
                    new { Text = "Jaboca Berry", Value = 211 },
                    new { Text = "Kasib Berry", Value = 196 },
                    new { Text = "Kebia Berry", Value = 190 },
                    new { Text = "Kelpsy Berry", Value = 170 },
                    new { Text = "King's Rock", Value = 221 },
                    new { Text = "Lagging Tail", Value = 279 },
                    new { Text = "Lansat Berry", Value = 206 },
                    new { Text = "Lava Cookie", Value = 42 },
                    new { Text = "Lax Incense", Value = 255 },
                    new { Text = "Leaf Stone", Value = 85 },
                    new { Text = "Leftovers", Value = 234 },
                    new { Text = "Lemonade", Value = 32 },
                    new { Text = "Leppa Berry", Value = 154 },
                    new { Text = "Level Ball", Value = 493 },
                    new { Text = "Liechi Berry", Value = 201 },
                    new { Text = "Life Orb", Value = 270 },
                    new { Text = "Light Ball", Value = 236 },
                    new { Text = "Light Clay", Value = 269 },
                    new { Text = "Like Mail", Value = 142 },
                    new { Text = "Love Ball", Value = 496 },
                    new { Text = "Luck Incense", Value = 319 },
                    new { Text = "Lucky Egg", Value = 231 },
                    new { Text = "Lucky Punch", Value = 256 },
                    new { Text = "Lum Berry", Value = 157 },
                    new { Text = "Lure Ball", Value = 494 },
                    new { Text = "Lustrous Orb", Value = 136 },
                    new { Text = "Luxury Ball", Value = 11 },
                    new { Text = "Macho Brace", Value = 215 },
                    new { Text = "Magmarizer", Value = 323 },
                    new { Text = "Magnet", Value = 242 },
                    new { Text = "Mago Berry", Value = 161 },
                    new { Text = "Magost Berry", Value = 176 },
                    new { Text = "Master Ball", Value = 1 },
                    new { Text = "Max Elixir", Value = 41 },
                    new { Text = "Max Ether", Value = 39 },
                    new { Text = "Max Potion", Value = 24 },
                    new { Text = "Max Repel", Value = 77 },
                    new { Text = "Max Revive", Value = 29 },
                    new { Text = "Meadow Plate", Value = 301 },
                    new { Text = "Mental Herb", Value = 219 },
                    new { Text = "Metal Coat", Value = 233 },
                    new { Text = "Metal Powder", Value = 257 },
                    new { Text = "Metronome", Value = 277 },
                    new { Text = "Micle Berry", Value = 209 },
                    new { Text = "Mind Plate", Value = 307 },
                    new { Text = "Miracle Seed", Value = 239 },
                    new { Text = "Moomoo Milk", Value = 33 },
                    new { Text = "Moon Ball", Value = 498 },
                    new { Text = "Moon Stone", Value = 81 },
                    new { Text = "Muscle Band", Value = 266 },
                    new { Text = "Muscle Wing", Value = 566 },
                    new { Text = "Mystic Water", Value = 243 },
                    new { Text = "Nanab Berry", Value = 166 },
                    new { Text = "Nest Ball", Value = 8 },
                    new { Text = "Net Ball", Value = 6 },
                    new { Text = "NeverMeltIce", Value = 246 },
                    new { Text = "Nomel Berry", Value = 178 },
                    new { Text = "Normal Gem", Value = 564 },
                    new { Text = "Nugget", Value = 92 },
                    new { Text = "Occa Berry", Value = 184 },
                    new { Text = "Odd Incense", Value = 314 },
                    new { Text = "Odd Keystone", Value = 111 },
                    new { Text = "Old Amber", Value = 103 },
                    new { Text = "Old Gateau", Value = 54 },
                    new { Text = "Oran Berry", Value = 155 },
                    new { Text = "Oval Stone", Value = 110 },
                    new { Text = "Pamtre Berry", Value = 180 },
                    new { Text = "Park Ball", Value = 500 },
                    new { Text = "Parlyz Heal", Value = 22 },
                    new { Text = "Pass Orb", Value = 575 },
                    new { Text = "Passho Berry", Value = 185 },
                    new { Text = "Payapa Berry", Value = 193 },
                    new { Text = "Pearl", Value = 88 },
                    new { Text = "Pearl String", Value = 582 },
                    new { Text = "Pecha Berry", Value = 151 },
                    new { Text = "Persim Berry", Value = 156 },
                    new { Text = "Petaya Berry", Value = 204 },
                    new { Text = "Photo Album", Value = 501 },
                    new { Text = "Pinap Berry", Value = 168 },
                    new { Text = "Pink Scarf", Value = 262 },
                    new { Text = "Plume Fossil", Value = 573 },
                    new { Text = "Poison Barb", Value = 245 },
                    new { Text = "Poison Gem", Value = 554 },
                    new { Text = "Poké Ball", Value = 4 },
                    new { Text = "Poké Doll", Value = 63 },
                    new { Text = "Poké Toy", Value = 577 },
                    new { Text = "Pomeg Berry", Value = 169 },
                    new { Text = "Potion", Value = 17 },
                    new { Text = "Power Anklet", Value = 293 },
                    new { Text = "Power Band", Value = 292 },
                    new { Text = "Power Belt", Value = 290 },
                    new { Text = "Power Bracer", Value = 289 },
                    new { Text = "Power Herb", Value = 271 },
                    new { Text = "Power Lens", Value = 291 },
                    new { Text = "Power Weight", Value = 294 },
                    new { Text = "PP Max", Value = 53 },
                    new { Text = "PP Up", Value = 51 },
                    new { Text = "Premier Ball", Value = 12 },
                    new { Text = "Pretty Wing", Value = 571 },
                    new { Text = "Prism Scale", Value = 537 },
                    new { Text = "Protector", Value = 321 },
                    new { Text = "Protein", Value = 46 },
                    new { Text = "Psychic Gem", Value = 557 },
                    new { Text = "Pure Incense", Value = 320 },
                    new { Text = "Qualot Berry", Value = 171 },
                    new { Text = "Quick Ball", Value = 15 },
                    new { Text = "Quick Claw", Value = 217 },
                    new { Text = "Quick Powder", Value = 274 },
                    new { Text = "Rabuta Berry", Value = 177 },
                    new { Text = "RageCandyBar", Value = 504 },
                    new { Text = "Rare Bone", Value = 106 },
                    new { Text = "Rare Candy", Value = 50 },
                    new { Text = "Rawst Berry", Value = 152 },
                    new { Text = "Razor Claw", Value = 326 },
                    new { Text = "Razor Fang", Value = 327 },
                    new { Text = "Razz Berry", Value = 164 },
                    new { Text = "Reaper Cloth", Value = 325 },
                    new { Text = "Red Card", Value = 542 },
                    new { Text = "Red Flute", Value = 67 },
                    new { Text = "Red Scarf", Value = 260 },
                    new { Text = "Red Shard", Value = 72 },
                    new { Text = "Relic Band", Value = 588 },
                    new { Text = "Relic Copper", Value = 584 },
                    new { Text = "Relic Crown", Value = 590 },
                    new { Text = "Relic Gold", Value = 586 },
                    new { Text = "Relic Silver", Value = 585 },
                    new { Text = "Relic Statue", Value = 589 },
                    new { Text = "Relic Vase", Value = 587 },
                    new { Text = "Repeat Ball", Value = 9 },
                    new { Text = "Repel", Value = 79 },
                    new { Text = "Reply Mail", Value = 143 },
                    new { Text = "Resist Wing", Value = 567 },
                    new { Text = "Revival Herb", Value = 37 },
                    new { Text = "Revive", Value = 28 },
                    new { Text = "Rindo Berry", Value = 187 },
                    new { Text = "Ring Target", Value = 543 },
                    new { Text = "Rock Gem", Value = 559 },
                    new { Text = "Rock Incense", Value = 315 },
                    new { Text = "Rocky Helmet", Value = 540 },
                    new { Text = "Root Fossil", Value = 99 },
                    new { Text = "Rose Incense", Value = 318 },
                    new { Text = "Rowap Berry", Value = 212 },
                    new { Text = "RSVP Mail", Value = 139 },
                    new { Text = "Sacred Ash", Value = 44 },
                    new { Text = "Safari Ball", Value = 5 },
                    new { Text = "Salac Berry", Value = 203 },
                    new { Text = "Scope Lens", Value = 232 },
                    new { Text = "Sea Incense", Value = 254 },
                    new { Text = "Sharp Beak", Value = 244 },
                    new { Text = "Shed Shell", Value = 295 },
                    new { Text = "Shell Bell", Value = 253 },
                    new { Text = "Shiny Stone", Value = 107 },
                    new { Text = "Shoal Salt", Value = 70 },
                    new { Text = "Shoal Shell", Value = 71 },
                    new { Text = "Shock Drive", Value = 117 },
                    new { Text = "Shuca Berry", Value = 191 },
                    new { Text = "Silk Scarf", Value = 251 },
                    new { Text = "SilverPowder", Value = 222 },
                    new { Text = "Sitrus Berry", Value = 158 },
                    new { Text = "Skull Fossil", Value = 105 },
                    new { Text = "Sky Plate", Value = 306 },
                    new { Text = "Smoke Ball", Value = 228 },
                    new { Text = "Smooth Rock", Value = 283 },
                    new { Text = "Soda Pop", Value = 31 },
                    new { Text = "Soft Sand", Value = 237 },
                    new { Text = "Soothe Bell", Value = 218 },
                    new { Text = "Soul Dew", Value = 225 },
                    new { Text = "Spell Tag", Value = 247 },
                    new { Text = "Spelon Berry", Value = 179 },
                    new { Text = "Splash Plate", Value = 299 },
                    new { Text = "Spooky Plate", Value = 310 },
                    new { Text = "Sport Ball", Value = 499 },
                    new { Text = "Stable Mulch", Value = 97 },
                    new { Text = "Star Piece", Value = 91 },
                    new { Text = "Stardust", Value = 90 },
                    new { Text = "Starf Berry", Value = 207 },
                    new { Text = "Steel Gem", Value = 563 },
                    new { Text = "Stick", Value = 259 },
                    new { Text = "Sticky Barb", Value = 288 },
                    new { Text = "Stone Plate", Value = 309 },
                    new { Text = "Sun Stone", Value = 80 },
                    new { Text = "Super Potion", Value = 26 },
                    new { Text = "Super Repel", Value = 76 },
                    new { Text = "Sweet Heart", Value = 134 },
                    new { Text = "Swift Wing", Value = 570 },
                    new { Text = "Tamato Berry", Value = 174 },
                    new { Text = "Tanga Berry", Value = 194 },
                    new { Text = "Thanks Mail", Value = 140 },
                    new { Text = "Thick Club", Value = 258 },
                    new { Text = "Thunder Stone", Value = 83 },
                    new { Text = "Tidal Bell", Value = 503 },
                    new { Text = "Timer Ball", Value = 10 },
                    new { Text = "TinyMushroom", Value = 86 },
                    new { Text = "TM01", Value = 328 },
                    new { Text = "TM02", Value = 329 },
                    new { Text = "TM03", Value = 330 },
                    new { Text = "TM04", Value = 331 },
                    new { Text = "TM05", Value = 332 },
                    new { Text = "TM06", Value = 333 },
                    new { Text = "TM07", Value = 334 },
                    new { Text = "TM08", Value = 335 },
                    new { Text = "TM09", Value = 336 },
                    new { Text = "TM10", Value = 337 },
                    new { Text = "TM11", Value = 338 },
                    new { Text = "TM12", Value = 339 },
                    new { Text = "TM13", Value = 340 },
                    new { Text = "TM14", Value = 341 },
                    new { Text = "TM15", Value = 342 },
                    new { Text = "TM16", Value = 343 },
                    new { Text = "TM17", Value = 344 },
                    new { Text = "TM18", Value = 345 },
                    new { Text = "TM19", Value = 346 },
                    new { Text = "TM20", Value = 347 },
                    new { Text = "TM21", Value = 348 },
                    new { Text = "TM22", Value = 349 },
                    new { Text = "TM23", Value = 350 },
                    new { Text = "TM24", Value = 351 },
                    new { Text = "TM25", Value = 352 },
                    new { Text = "TM26", Value = 353 },
                    new { Text = "TM27", Value = 354 },
                    new { Text = "TM28", Value = 355 },
                    new { Text = "TM29", Value = 356 },
                    new { Text = "TM30", Value = 357 },
                    new { Text = "TM31", Value = 358 },
                    new { Text = "TM32", Value = 359 },
                    new { Text = "TM33", Value = 360 },
                    new { Text = "TM34", Value = 361 },
                    new { Text = "TM35", Value = 362 },
                    new { Text = "TM36", Value = 363 },
                    new { Text = "TM37", Value = 364 },
                    new { Text = "TM38", Value = 365 },
                    new { Text = "TM39", Value = 366 },
                    new { Text = "TM40", Value = 367 },
                    new { Text = "TM41", Value = 368 },
                    new { Text = "TM42", Value = 369 },
                    new { Text = "TM43", Value = 370 },
                    new { Text = "TM44", Value = 371 },
                    new { Text = "TM45", Value = 372 },
                    new { Text = "TM46", Value = 373 },
                    new { Text = "TM47", Value = 374 },
                    new { Text = "TM48", Value = 375 },
                    new { Text = "TM49", Value = 376 },
                    new { Text = "TM50", Value = 377 },
                    new { Text = "TM51", Value = 378 },
                    new { Text = "TM52", Value = 379 },
                    new { Text = "TM53", Value = 380 },
                    new { Text = "TM54", Value = 381 },
                    new { Text = "TM55", Value = 382 },
                    new { Text = "TM56", Value = 383 },
                    new { Text = "TM57", Value = 384 },
                    new { Text = "TM58", Value = 385 },
                    new { Text = "TM59", Value = 386 },
                    new { Text = "TM60", Value = 387 },
                    new { Text = "TM61", Value = 388 },
                    new { Text = "TM62", Value = 389 },
                    new { Text = "TM63", Value = 390 },
                    new { Text = "TM64", Value = 391 },
                    new { Text = "TM65", Value = 392 },
                    new { Text = "TM66", Value = 393 },
                    new { Text = "TM67", Value = 394 },
                    new { Text = "TM68", Value = 395 },
                    new { Text = "TM69", Value = 396 },
                    new { Text = "TM70", Value = 397 },
                    new { Text = "TM71", Value = 398 },
                    new { Text = "TM72", Value = 399 },
                    new { Text = "TM73", Value = 400 },
                    new { Text = "TM74", Value = 401 },
                    new { Text = "TM75", Value = 402 },
                    new { Text = "TM76", Value = 403 },
                    new { Text = "TM77", Value = 404 },
                    new { Text = "TM78", Value = 405 },
                    new { Text = "TM79", Value = 406 },
                    new { Text = "TM80", Value = 407 },
                    new { Text = "TM81", Value = 408 },
                    new { Text = "TM82", Value = 409 },
                    new { Text = "TM83", Value = 410 },
                    new { Text = "TM84", Value = 411 },
                    new { Text = "TM85", Value = 412 },
                    new { Text = "TM86", Value = 413 },
                    new { Text = "TM87", Value = 414 },
                    new { Text = "TM88", Value = 415 },
                    new { Text = "TM89", Value = 416 },
                    new { Text = "TM90", Value = 417 },
                    new { Text = "TM91", Value = 418 },
                    new { Text = "TM92", Value = 419 },
                    new { Text = "Toxic Orb", Value = 272 },
                    new { Text = "Toxic Plate", Value = 304 },
                    new { Text = "TwistedSpoon", Value = 248 },
                    new { Text = "Ultra Ball", Value = 2 },
                    new { Text = "Up-Grade", Value = 252 },
                    new { Text = "Wacan Berry", Value = 186 },
                    new { Text = "Water Gem", Value = 549 },
                    new { Text = "Water Stone", Value = 84 },
                    new { Text = "Watmel Berry", Value = 181 },
                    new { Text = "Wave Incense", Value = 317 },
                    new { Text = "Wepear Berry", Value = 167 },
                    new { Text = "White Flute", Value = 69 },
                    new { Text = "White Herb", Value = 214 },
                    new { Text = "Wide Lens", Value = 265 },
                    new { Text = "Wiki Berry", Value = 160 },
                    new { Text = "Wise Glasses", Value = 267 },
                    new { Text = "X Accuracy", Value = 60 },
                    new { Text = "X Attack", Value = 57 },
                    new { Text = "X Defend", Value = 58 },
                    new { Text = "X Sp. Def", Value = 62 },
                    new { Text = "X Special", Value = 61 },
                    new { Text = "X Speed", Value = 59 },
                    new { Text = "Yache Berry", Value = 188 },
                    new { Text = "Yellow Flute", Value = 66 },
                    new { Text = "Yellow Scarf", Value = 264 },
                    new { Text = "Yellow Shard", Value = 74 },
                    new { Text = "Zap Plate", Value = 300 },
                    new { Text = "Zinc", Value = 52 },
                    new { Text = "Zoom Lens", Value = 276 },
            };

            // Initialize Fields
            ComboBox[] box = cbtable();
            for (int i = 0; i < box.Length; i++)
            {
                box[i].DataSource = new BindingSource(item_list, null);
                box[i].DisplayMember = "Text";
                box[i].ValueMember = "Value";
            }
        }
        private void loaddata()
        {
            for (int j=0; j<80; j++)
            {
                FileStream InStream = File.OpenRead(filepaths[j]);
                BinaryReader br = new BinaryReader(InStream);
                
                for (int i = 0; i < br.BaseStream.Length; i+=2)
                {
                    data[j,i/2]=(int)(br.ReadByte() + (br.ReadByte())*0x100);
                }
                br.Close();
            }
            N_UD.Enabled = true;
            TC.Enabled = true;
            filldata();
        }
        private void savedata()
        {
            for (int j = 0; j < 80; j++)
            {
                // Package up the Mart File
                byte[] buff = { (byte)(data[j, 0] & 0xFF), (byte)(data[j, 0] >> 8) };
                for (int i=1; i<20; i++)
                {
                    if (data[j, i] > 0) // Make sure that it's not just blank.
                    {
                        byte[] a = { (byte)(data[j, i] & 0xFF), (byte)(data[j, i] >> 8) };
                        buff = buff.Concat(a).ToArray();
                    }
                }
                File.WriteAllBytes(filepaths[j],buff);
            }
        }
        private void filldata()
        {
            filling = true;
            ComboBox[] box = cbtable();
            for (int i = 0; i < 20; i++)
            {
                box[i].SelectedValue = data[(int)(N_UD.Value),i];
            }
            filling = false;
        }
        private void reset()
        {
            int[,] data = new int[80, 20];
            ComboBox[] box = cbtable();
            for (int i = 0; i < 20; i++)
            {
                box[i].SelectedIndex = 0;
            }
        }

        private ComboBox[] cbtable()
        {
            ComboBox[] box = { C_Item1, C_Item2, C_Item3, C_Item4, C_Item5, C_Item6, C_Item7, C_Item8, C_Item9, C_Item10, C_Item11, C_Item12, C_Item13, C_Item14, C_Item15, C_Item16, C_Item17, C_Item18, C_Item19, C_Item20, };
            return box;
        }
        private int ToInt32(String value)
        {
            if (String.IsNullOrEmpty(value))
                return 0;
            return Int32.Parse(value);
        }
        private int getindex(ComboBox cb)
        {
            int val = 0;
            try { val = ToInt32(cb.SelectedValue.ToString()); }
            catch { };
            return val;
        }

        private void changenud(object sender, EventArgs e)
        {
            filldata();
        }
        private void changeitem(object sender, EventArgs e)
        {
            if (!filling)
            {
                ComboBox[] box = cbtable();
                for (int i = 0; i < 20; i++)
                {
                    data[(int)(N_UD.Value), i] = getindex(box[i]);
                }
            }
        }
        private void openlist(object sender, EventArgs e)
        {
            string message = "0 - Stock No Badges\n1 - Stock 1+Badges\n2 - Stock 3+Badges\n3 - Stock 5+Badges\n4 - Stock 7+Badges\n5 - Stock 8+Badges\n6 - Accumula Town Upper\n7 - Striaton City Upper\n8 - Nacrene City Upper\n9 - Castelia City Upper\n10 - Nimbasa TM Department\n11 - Driftveil City Upper\n12 - Mistralton City TM Dept.\n13 - Icirrus City Upper\n14 - Opelucid City Upper\n15 - Victory Road Upper\n16 - Victory Road Upper2\n17 - Lacunosa Town\n18 - Undella Town\n19 - Black City\n20 - SM9 Top Right Cashier\n21 - Driftveil City Herb Shop\n22 - Driftveil City Inscense Shop\n23 - SM9 Bottom Section\n24 - SM9 Middle Right Cashier\n25 - SM9 Middle Left Cashier\n26 - SM9 Top Left Cashier\n27 - Aspertia City?\n28 - Virbank City Lower Cashier\n29 - Humilau City Upper Cashier\n30 - Floccesy Town?\n31 - Lentimas Town Upper Cashier\n";
            string caption = "Location List";
            MessageBox.Show(message, caption);
        }
        private void B_Open_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                filepaths = Directory.GetFiles(fbd.SelectedPath, "*.*", SearchOption.AllDirectories);
                N_UD.Value = 0;
                loaddata();
            }
            B_Save.Enabled = true;
            B_List.Enabled = true;
        }
        private void B_Save_Click(object sender, EventArgs e)
        {
            try
            {
                savedata();
                MessageBox.Show("Data saved!");
            }
            catch (Exception ex)
            {
                string message = "Exception Error:\n\n" + ex + "\n\nFix this before saving.";
                string caption = "Error!";
                MessageBox.Show(message, caption);
            }
            reset();
            loaddata();
        }
    }
}
