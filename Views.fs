namespace LpbGO.Views

open Giraffe.ViewEngine

module AppViews =

    let indexCss = """

        @import url('https://fonts.googleapis.com/css2?family=Outfit:wght@300;400;600;700&display=swap');

        :root {
            --bg-color: #0f172a;
            --glass-bg: rgba(30, 41, 59, 0.7);
            --glass-border: rgba(255, 255, 255, 0.1);
            --primary: #10b981;
            --primary-hover: #059669;
            --text-main: #f8fafc;
            --text-muted: #94a3b8;
        }

        * {
            box-sizing: border-box;
            margin: 0;
            padding: 0;
            font-family: 'Outfit', sans-serif;
        }

        body {
            background-color: var(--bg-color);
            background-image: radial-gradient(circle at top right, #1e293b, #0f172a);
            color: var(--text-main);
            min-height: 100vh;
            display: flex;
            flex-direction: column;
            align-items: center;
            padding: 2rem;
        }

        .header {
            text-align: center;
            margin-bottom: 3rem;
        }

        .header h1 {
            font-size: 3rem;
            font-weight: 700;
            background: linear-gradient(135deg, #34d399, #10b981);
            -webkit-background-clip: text;
            background-clip: text;
            -webkit-text-fill-color: transparent;
            margin-bottom: 0.5rem;
        }

        .header p {
            color: var(--text-muted);
            font-size: 1.1rem;
        }

        .container {
            width: 100%;
            max-width: 500px;
            background: var(--glass-bg);
            backdrop-filter: blur(12px);
            border: 1px solid var(--glass-border);
            border-radius: 24px;
            padding: 2rem;
            box-shadow: 0 25px 50px -12px rgba(0, 0, 0, 0.5);
            animation: slideUp 0.6s cubic-bezier(0.16, 1, 0.3, 1);
        }

        @keyframes slideUp {
            from { opacity: 0; transform: translateY(30px); }
            to { opacity: 1; transform: translateY(0); }
        }

        .form-group {
            margin-bottom: 1.5rem;
            display: flex;
            flex-direction: column;
            gap: 0.5rem;
        }

        label {
            font-size: 0.9rem;
            font-weight: 600;
            color: var(--text-muted);
            text-transform: uppercase;
            letter-spacing: 0.05em;
        }

        select {
            appearance: none;
            background: rgba(15, 23, 42, 0.8);
            border: 1px solid var(--glass-border);
            color: white;
            padding: 1rem;
            border-radius: 12px;
            font-size: 1rem;
            outline: none;
            transition: all 0.3s ease;
        }

        select:focus {
            border-color: var(--primary);
            box-shadow: 0 0 0 3px rgba(16, 185, 129, 0.2);
        }

        button.search-btn {
            width: 100%;
            padding: 1.2rem;
            background: var(--primary);
            color: white;
            border: none;
            border-radius: 12px;
            font-size: 1.1rem;
            font-weight: 600;
            cursor: pointer;
            transition: all 0.3s ease;
            margin-top: 1rem;
        }

        button.search-btn:hover {
            background: var(--primary-hover);
            transform: translateY(-2px);
            box-shadow: 0 10px 20px -10px var(--primary);
        }

        .results {
            margin-top: 2rem;
            display: flex;
            flex-direction: column;
            gap: 1rem;
        }

        .route-card {
            background: rgba(15, 23, 42, 0.6);
            border: 1px solid var(--glass-border);
            border-radius: 16px;
            padding: 1.5rem;
            display: flex;
            justify-content: space-between;
            align-items: center;
            transition: transform 0.2s ease;
            cursor: pointer;
            position: relative;
            overflow: hidden;
        }
        
        .route-card::before {
            content: '';
            position: absolute;
            top: 0; left: 0; width: 4px; height: 100%;
            background: var(--primary);
        }

        .route-card:hover {
            transform: scale(1.02);
            background: rgba(30, 41, 59, 1);
        }

        .route-card.expanded {
            transform: scale(1.02);
            background: rgba(30, 41, 59, 1);
            cursor: default;
        }

        .route-card.expanded::before {
            background: #3b82f6; /* Highlight when expanded */
        }

        .route-details {
            display: none;
            margin-top: 1.5rem;
            padding-top: 1.5rem;
            border-top: 1px dashed var(--glass-border);
            animation: slideUp 0.3s ease;
        }

        .route-card.expanded .route-details {
            display: block;
        }

        .timeline {
            position: relative;
            padding-left: 1.5rem;
            margin-bottom: 1.5rem;
        }

        .timeline::before {
            content: '';
            position: absolute;
            left: 0.4rem;
            top: 0.5rem;
            bottom: 0.5rem;
            width: 2px;
            background: rgba(255,255,255,0.2);
        }

        .timeline-stop {
            position: relative;
            margin-bottom: 1.5rem;
        }

        .timeline-stop:last-child {
            margin-bottom: 0;
        }

        .timeline-stop::before {
            content: '';
            position: absolute;
            left: -1.35rem;
            top: 0.2rem;
            width: 10px;
            height: 10px;
            border-radius: 50%;
            background: var(--bg-color);
            border: 2px solid var(--primary);
            z-index: 1;
        }

        .timeline-stop.passed::before {
            background: var(--primary);
            box-shadow: 0 0 10px var(--primary);
        }

        .timeline-time {
            font-size: 0.85rem;
            color: var(--primary);
            font-weight: 600;
            margin-bottom: 0.2rem;
        }

        .timeline-name {
            font-size: 1rem;
            color: var(--text-main);
        }

        .book-btn {
            width: 100%;
            padding: 1rem;
            background: linear-gradient(135deg, #10b981, #059669);
            color: white;
            border: none;
            border-radius: 12px;
            font-weight: bold;
            font-size: 1.1rem;
            cursor: pointer;
            transition: 0.3s ease;
            box-shadow: 0 4px 15px rgba(16, 185, 129, 0.3);
            display: flex;
            align-items: center;
            justify-content: center;
            gap: 10px;
        }

        .book-btn:hover {
            transform: translateY(-2px);
            box-shadow: 0 8px 20px rgba(16, 185, 129, 0.5);
        }

        .route-times {
            font-size: 1.4rem;
            font-weight: 700;
        }

        .route-times span {
            color: var(--text-muted);
            font-size: 1rem;
            font-weight: 400;
            margin: 0 0.5rem;
        }

        .route-price {
            font-size: 1.2rem;
            font-weight: 600;
            color: var(--primary);
            text-align: right;
        }
        
        .no-results {
            text-align: center;
            color: var(--text-muted);
            padding: 2rem 0;
            font-size: 1.1rem;
        }

        .fullscreen-ticket {
            position: fixed;
            top: 0; left: 0; width: 100%; height: 100%;
            background: #1e293b;
            z-index: 2000;
            display: none;
            flex-direction: column;
            align-items: center;
            justify-content: center;
            animation: fadeIn 0.3s ease;
        }

        .ticket-header {
            position: absolute;
            top: 0; left: 0; width: 100%;
            background: var(--primary);
            color: #fff;
            padding: 1rem;
            text-align: center;
            font-size: 1.2rem;
            font-weight: bold;
            box-shadow: 0 4px 15px rgba(0,0,0,0.3);
            display: flex;
            justify-content: space-between;
        }

        .ticket-animation-box {
            width: 80vw;
            height: 80vw;
            max-width: 300px;
            max-height: 300px;
            background: white;
            border-radius: 20px;
            display: flex;
            align-items: center;
            justify-content: center;
            position: relative;
            box-shadow: 0 0 50px rgba(16, 185, 129, 0.4);
            border: 8px solid var(--primary);
            overflow: hidden;
        }
        
        .pulse-overlay {
            position: absolute;
            top: 0; left: 0; width: 100%; height: 100%;
            background: linear-gradient(180deg, transparent 0%, rgba(16, 185, 129, 0.2) 50%, transparent 100%);
            animation: scanline 2s linear infinite;
        }

        @keyframes scanline {
            0% { transform: translateY(-100%); }
            100% { transform: translateY(100%); }
        }

        @keyframes fadeIn {
            from { opacity: 0; }
            to { opacity: 1; }
        }

        .action-btn {
            background: var(--primary); color: white;
            border: none; padding: 0.8rem 1.5rem;
            border-radius: 8px; cursor: pointer; font-size: 1rem;
            font-weight: 600; transition: all 0.2s;
            margin-right: 10px;
        }
        .action-btn:hover { background: var(--primary-hover); }

        .modal-overlay {
            position: fixed;
            top: 0; left: 0; width: 100%; height: 100%;
            background: rgba(15, 23, 42, 0.8);
            backdrop-filter: blur(4px);
            z-index: 1000;
            display: none;
            align-items: center;
            justify-content: center;
            animation: fadeIn 0.3s ease;
        }

        .modal {
            background: var(--glass-bg);
            border: 1px solid var(--glass-border);
            border-radius: 20px;
            padding: 2.5rem;
            width: 90%;
            max-width: 400px;
            text-align: center;
            box-shadow: 0 25px 50px -12px rgba(0, 0, 0, 0.5);
            display: flex;
            flex-direction: column;
            align-items: center;
        }

        .modal h2 {
            margin-bottom: 0.5rem;
            color: var(--text-main);
        }

        .modal #paymentAmount {
            color: var(--primary);
            font-size: 1.5rem;
            font-weight: 700;
            margin-bottom: 1.5rem;
        }

        .modal img {
            width: 250px;
            height: 250px;
            background: white;
            padding: 10px;
            border-radius: 16px;
            margin-bottom: 1.5rem;
        }

        .close-btn {
            background: transparent;
            color: var(--text-muted);
            border: 1px solid var(--glass-border);
            padding: 0.8rem 1.5rem;
            border-radius: 8px;
            cursor: pointer;
            font-size: 1rem;
            font-weight: 600;
            transition: all 0.2s;
        }

        .close-btn:hover {
            background: rgba(255, 255, 255, 0.1);
            color: white;
        }

        .support-fab {
            position: fixed;
            bottom: 2rem;
            right: 2rem;
            background: var(--primary);
            color: white;
            width: 60px;
            height: 60px;
            border-radius: 50%;
            display: flex;
            align-items: center;
            justify-content: center;
            font-size: 1.5rem;
            box-shadow: 0 10px 25px rgba(16, 185, 129, 0.5);
            cursor: pointer;
            transition: transform 0.3s;
            z-index: 100;
        }

        .support-fab:hover {
            transform: scale(1.1);
        }

        .support-panel {
            position: fixed;
            bottom: 6rem;
            right: 2rem;
            width: 320px;
            background: var(--glass-bg);
            backdrop-filter: blur(12px);
            border: 1px solid var(--glass-border);
            border-radius: 20px;
            padding: 1.5rem;
            box-shadow: 0 25px 50px rgba(0, 0, 0, 0.5);
            display: none;
            flex-direction: column;
            z-index: 1000;
            animation: slideUp 0.3s ease;
        }

        .support-panel h3 {
            margin-bottom: 1rem;
        }

        .support-panel select, .support-panel textarea {
            width: 100%;
            background: rgba(15, 23, 42, 0.8);
            border: 1px solid var(--glass-border);
            color: white;
            padding: 0.8rem;
            border-radius: 8px;
            margin-bottom: 1rem;
            font-family: inherit;
        }

        .support-panel textarea {
            resize: none;
            height: 100px;
        }
    
"""

    let indexJs = """

        let currentBookingScheduleId = null;

        // Load locations on startup
        async function init() {
            try {
                const res = await fetch('/transport/locations');
                const locations = await res.json();
                const fromSelect = document.getElementById('fromLocation');
                const toSelect = document.getElementById('toLocation');

                locations.forEach(loc => {
                    fromSelect.add(new Option(loc.name, loc.id));
                    toSelect.add(new Option(loc.name, loc.id));
                });
            } catch (err) {
                console.error("Failed to load locations", err);
            }
        }

        async function searchRoutes() {
            const fromId = document.getElementById('fromLocation').value;
            const toId = document.getElementById('toLocation').value;
            const resultsArea = document.getElementById('resultsArea');
            
            resultsArea.innerHTML = '<div class="no-results">Searching...</div>';

            let url = '/transport/schedules?';
            if (fromId) url += `fromLocationId=${fromId}&`;
            if (toId) url += `toLocationId=${toId}`;

            try {
                const res = await fetch(url);
                const schedules = await res.json();

                if (schedules.length === 0) {
                    resultsArea.innerHTML = '<div class="no-results">No direct routes found.</div>';
                    return;
                }

                resultsArea.innerHTML = '';
                schedules.forEach(schedule => {
                    const priceFormatted = new Intl.NumberFormat('en-US').format(schedule.priceInKip);
                    const card = `
                        <div class="route-card" onclick="toggleRouteDetails(this)">
                            <div style="display:flex; justify-content: space-between; width: 100%; align-items: center; pointer-events: none;">
                                <div>
                                    <div class="route-times">
                                        ${schedule.departureTime} <span>&rarr;</span> ${schedule.arrivalTime}
                                    </div>
                                    <div style="color: #10b981; font-size: 0.9rem; margin-top: 0.3rem;">
                                        Route ID #${schedule.routeId} 
                                    </div>
                                </div>
                                <div class="route-price">
                                    ₭${priceFormatted}
                                    <div style="font-size: 0.8rem; opacity: 0.7; color: var(--text-muted); font-weight: normal; margin-top: 0.2rem;">Tap to expand ▼</div>
                                </div>
                            </div>
                            <div class="route-details" onclick="event.stopPropagation()">
                                <div class="timeline">
                                    <div class="timeline-stop passed">
                                        <div class="timeline-time">${schedule.departureTime}</div>
                                        <div class="timeline-name">Departure Point</div>
                                    </div>
                                    <div class="timeline-stop">
                                        <div class="timeline-time">En route</div>
                                        <div class="timeline-name">Intermediate Stop (City Center)</div>
                                    </div>
                                    <div class="timeline-stop">
                                        <div class="timeline-time">${schedule.arrivalTime}</div>
                                        <div class="timeline-name">Arrival Point (Destination)</div>
                                    </div>
                                </div>
                                <button class="book-btn" onclick="bookTicket(${schedule.id}, ${schedule.priceInKip})">
                                    <svg width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"><rect x="2" y="5" width="20" height="14" rx="2"/><line x1="2" y1="10" x2="22" y2="10"/></svg>
                                    Pay ₭${priceFormatted} with Phajay
                                </button>
                            </div>
                        </div>
                    `;
                    resultsArea.insertAdjacentHTML('beforeend', card);
                });

            } catch(e) {
                resultsArea.innerHTML = '<div class="no-results" style="color: #ef4444">Error loading schedules.</div>';
            }
        }

        function toggleRouteDetails(element) {
            // Collapse others
            document.querySelectorAll('.route-card.expanded').forEach(card => {
                if(card !== element) card.classList.remove('expanded');
            });
            element.classList.toggle('expanded');
        }

        async function bookTicket(scheduleId, priceInKip) {
            currentBookingScheduleId = scheduleId;
            document.getElementById('paymentModal').style.display = 'flex';
            document.getElementById('paymentAmount').innerText = 'Generating QR...';
            document.getElementById('qrCodeImage').style.opacity = '0.5';

            try {
                const res = await fetch('/tickets/phajay/' + scheduleId, { method: 'POST' });
                if (!res.ok) throw new Error("Failed to generate QR");
                
                const data = await res.json();
                
                const priceFormatted = new Intl.NumberFormat('en-US').format(data.amount);
                document.getElementById('paymentAmount').innerText = 'Amount: ₭' + priceFormatted;
                document.getElementById('qrCodeImage').src = data.qrCodeUrl;
                document.getElementById('qrCodeImage').style.opacity = '1';
                
            } catch (e) {
                alert('Error connecting to Phajay API');
                closeModal();
            }
        }

        async function simulatePaymentComplete() {
            if (!currentBookingScheduleId) return;

            try {
                const reqData = { UserId: "mobileUser_88", ScheduleId: currentBookingScheduleId };
                const res = await fetch('/tickets/purchase', {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json' },
                    body: JSON.stringify(reqData)
                });
                
                if (!res.ok) throw new Error("Purchase failed");

                const ticketData = await res.json();
                closeModal();
                showLiveTicket(ticketData);

            } catch(e) {
                alert('Payment verification failed.');
            }
        }

        function showLiveTicket(ticketData) {
            document.getElementById('liveTicket').style.display = 'flex';
            
            // Generate a QR code for the actual valid ticket (just a QR wrapping the GUID)
            const validateUrl = `https://api.qrserver.com/v1/create-qr-code/?size=300x300&data=VALID_TICKET:${ticketData.id}`;
            document.getElementById('finalTicketQR').src = validateUrl;
            
            // Format nice date
            const dateStr = new Date(ticketData.purchaseDate).toLocaleString();
            document.getElementById('ticketDate').innerText = 'Valid since: ' + dateStr;
            document.getElementById('ticketIdDisplay').innerText = ticketData.id.split('-')[0].toUpperCase();
            
            // Make pulse active
            document.getElementById('scanPulse').style.display = 'block';
        }

        function closeTicket() {
            document.getElementById('liveTicket').style.display = 'none';
        }

        function closeModal() {
            document.getElementById('paymentModal').style.display = 'none';
        }

        // Run setup
        init();

        // Support functions
        function toggleSupport() {
            const panel = document.getElementById('supportPanel');
            panel.style.display = panel.style.display === 'flex' ? 'none' : 'flex';
        }

        async function submitSupport() {
            const category = document.getElementById('supportCategory').value;
            const message = document.getElementById('supportMessage').value;

            if(!message) {
                alert("Please enter a message");
                return;
            }

            const btn = document.getElementById('supportSubmitBtn');
            btn.innerText = "Sending...";
            btn.disabled = true;

            try {
                const res = await fetch('/support/submit', {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json' },
                    body: JSON.stringify({ Category: category, Message: message })
                });

                if(res.ok) {
                    alert('Message sent to our Support Team! We will look into it.');
                    toggleSupport();
                    document.getElementById('supportMessage').value = '';
                } else {
                    alert('Failed to send message.');
                }
            } catch(e) {
                alert('Connection error.');
            } finally {
                btn.innerText = "Send Message";
                btn.disabled = false;
            }
        }
    
"""

    let indexView = 
        html [ _lang "en" ] [
            head [] [
                meta [ _charset "UTF-8" ]
                meta [ _name "viewport"; _content "width=device-width, initial-scale=1.0" ]
                title [] [ str "LpbGO | Luang Prabang Transport" ]
                style [] [ rawText indexCss ]
            ]
            body [] [
                div [ _class "header" ] [
                    h1 [] [ str "LpbGO" ]
                    p [] [ str "Smart Travel in Luang Prabang" ]
                ]

                div [ _class "container" ] [
                    div [ _class "form-group" ] [
                        label [] [ str "Departure" ]
                        select [ _id "fromLocation" ] [
                            option [ _value "" ] [ str "Select departure point" ]
                        ]
                    ]
                    div [ _class "form-group" ] [
                        label [] [ str "Destination" ]
                        select [ _id "toLocation" ] [
                            option [ _value "" ] [ str "Select destination" ]
                        ]
                    ]
                    button [ _class "search-btn"; _onclick "searchRoutes()" ] [ str "Find Routes" ]
                    div [ _class "results"; _id "resultsArea" ] []
                ]

                div [ _class "modal-overlay"; _id "paymentModal" ] [
                    div [ _class "modal" ] [
                        h2 [] [ str "Phajay BCEL Payment" ]
                        p [ _id "paymentAmount" ] [ str "Amount: ₭0" ]
                        img [ _id "qrCodeImage"; _src ""; _alt "BCEL QR Code" ]
                        p [ _style "font-size: 0.8rem; margin-top: -0.5rem; margin-bottom: 1.5rem;" ] [ str "Scan using Phajay App / BCEL One" ]
                        div [] [
                            button [ _class "action-btn"; _onclick "simulatePaymentComplete()" ] [ str "I've Paid" ]
                            button [ _class "close-btn"; _onclick "closeModal()" ] [ str "Cancel" ]
                        ]
                    ]
                ]

                div [ _class "fullscreen-ticket"; _id "liveTicket" ] [
                    div [ _class "ticket-header" ] [
                        div [ _onclick "closeTicket()"; _style "cursor: pointer;" ] [ str " Back" ]
                        div [] [ str "Valid Ticket" ]
                        div [ _style "width: 50px;" ] []
                    ]
                    div [ _style "margin-bottom: 2rem; text-align: center;" ] [
                        h2 [ _id "ticketRouteTitle"; _style "margin-bottom: 0.5rem;" ] [ str "Bus Transfer" ]
                        p [ _id "ticketDate"; _style "color: var(--text-muted);" ] []
                    ]
                    div [ _class "ticket-animation-box"; _onclick "toggleQR()" ] [
                        img [ _id "finalTicketQR"; _src ""; _alt "Ticket Code"; _style "width: 90%; height: 90%; filter: drop-shadow(0px 0px 5px rgba(0,0,0,0.1));" ]
                        div [ _class "pulse-overlay"; _id "scanPulse" ] []
                    ]
                    p [ _style "margin-top: 2rem; color: var(--text-muted);" ] [ str "Show to Driver / Inspector" ]
                    div [ _id "ticketIdDisplay"; _style "margin-top: 1rem; font-family: monospace; font-size: 1.2rem; background: rgba(0,0,0,0.3); padding: 0.5rem 1rem; border-radius: 8px;" ] []
                ]

                div [ _class "support-fab"; _onclick "toggleSupport()" ] [ str "" ]

                div [ _class "support-panel"; _id "supportPanel" ] [
                    h3 [] [ str "Contact Support" ]
                    select [ _id "supportCategory" ] [
                        option [ _value "Payment Issue" ] [ str "Payment Issue" ]
                        option [ _value "Lost Item" ] [ str "Lost Item" ]
                        option [ _value "App Bug" ] [ str "App Bug" ]
                        option [ _value "General Question" ] [ str "General Question" ]
                    ]
                    textarea [ _id "supportMessage"; _placeholder "Describe your issue..." ] []
                    div [ _style "display: flex; gap: 10px;" ] [
                        button [ _id "supportSubmitBtn"; _class "action-btn"; _style "flex: 1; margin: 0;"; _onclick "submitSupport()" ] [ str "Send" ]
                        button [ _class "close-btn"; _style "padding: 0.8rem 1rem;"; _onclick "toggleSupport()" ] [ str "Cancel" ]
                    ]
                ]

                script [] [ rawText indexJs ]
            ]
        ]


    let inspectorCss = """

        @import url('https://fonts.googleapis.com/css2?family=Outfit:wght@300;400;600;700&display=swap');

        :root {
            --bg-color: #0f172a;
            --primary: #3b82f6; /* Blue for inspector */
            --success: #10b981;
            --danger: #ef4444;
            --text-main: #f8fafc;
        }

        body {
            background-color: var(--bg-color);
            color: var(--text-main);
            font-family: 'Outfit', sans-serif;
            margin: 0;
            padding: 2rem;
            display: flex;
            flex-direction: column;
            align-items: center;
        }

        h1 { margin-bottom: 0.5rem; text-align: center; color: var(--primary); }
        p { color: #94a3b8; text-align: center; margin-bottom: 2rem; }

        .scanner-container {
            width: 100%;
            max-width: 400px;
            background: white;
            border-radius: 16px;
            overflow: hidden;
            box-shadow: 0 10px 30px rgba(0,0,0,0.5);
        }

        #reader { width: 100%; }

        .result-panel {
            margin-top: 2rem;
            width: 100%;
            max-width: 400px;
            padding: 1.5rem;
            border-radius: 12px;
            text-align: center;
            font-weight: bold;
            font-size: 1.2rem;
            display: none;
            animation: slideUp 0.3s ease;
        }

        @keyframes slideUp {
            from { transform: translateY(20px); opacity: 0; }
            to { transform: translateY(0); opacity: 1; }
        }

        .success { background: rgba(16, 185, 129, 0.2); border: 2px solid var(--success); color: var(--success); }
        .error { background: rgba(239, 68, 68, 0.2); border: 2px solid var(--danger); color: var(--danger); }

        button {
            margin-top: 1rem;
            padding: 0.8rem 2rem;
            background: var(--text-main);
            color: var(--bg-color);
            border: none;
            border-radius: 8px;
            font-weight: 600;
            cursor: pointer;
        }
    
"""

    let inspectorJs = """

        let html5QrcodeScanner;

        function onScanSuccess(decodedText, decodedResult) {
            // Our tickets were generated with prefix "VALID_TICKET:"
            if(decodedText.startsWith("VALID_TICKET:")) {
                const ticketId = decodedText.split("VALID_TICKET:")[1];
                html5QrcodeScanner.pause(true); // Stop scanning while checking
                validateTicketOnServer(ticketId);
            } else {
                showResult("Invalid QR Format!", false);
            }
        }

        async function validateTicketOnServer(ticketId) {
            try {
                // Call the F# Validate Endpoint
                const res = await fetch('/tickets/validate/' + ticketId, { method: 'POST' });
                const data = await res.json();

                if (res.ok && data.success) {
                    showResult("âœ… Valid Ticket consumed!<br>Passenger can enter.", true);
                } else {
                    showResult("âŒ " + (data.message || "Ticket invalid or already used."), false);
                }
            } catch (err) {
                showResult("âŒ Network Error: Could not reach server.", false);
            }
        }

        function showResult(message, isSuccess) {
            const panel = document.getElementById('resultPanel');
            const text = document.getElementById('resultText');
            
            panel.className = 'result-panel ' + (isSuccess ? 'success' : 'error');
            text.innerHTML = message;
            panel.style.display = 'block';
        }

        function resetScanner() {
            document.getElementById('resultPanel').style.display = 'none';
            html5QrcodeScanner.resume(); // Resume webcam
        }

        // Initialize scanner when DOM loads
        window.addEventListener('load', () => {
            html5QrcodeScanner = new Html5QrcodeScanner(
                "reader", { fps: 10, qrbox: {width: 250, height: 250} }, /* verbose= */ false);
            html5QrcodeScanner.render(onScanSuccess);
        });
    
"""

    let inspectorView = 
        html [ _lang "en" ] [
            head [] [
                meta [ _charset "UTF-8" ]
                meta [ _name "viewport"; _content "width=device-width, initial-scale=1.0" ]
                title [] [ str "Inspector App - LpbGO" ]
                script [ _src "https://unpkg.com/html5-qrcode" ] []
                style [] [ rawText inspectorCss ]
            ]
            body [] [
                h1 [] [ str "Inspector Terminal" ]
                p [] [ str "Scan passenger QR codes to validate entry." ]

                div [ _class "scanner-container" ] [
                    div [ _id "reader" ] []
                ]

                div [ _id "resultPanel"; _class "result-panel" ] [
                    div [ _id "resultText" ] []
                    button [ _onclick "resetScanner()" ] [ str "Scan Next Ticket" ]
                ]

                script [] [ rawText inspectorJs ]
            ]
        ]


    let driverCss = """

        @import url('https://fonts.googleapis.com/css2?family=Outfit:wght@400;600;700&display=swap');

        :root {
            --bg-dark: #0f172a;
            --surface: #1e293b;
            --primary: #f59e0b; /* Amber for driver app */
            --primary-hover: #d97706;
            --danger: #ef4444;
            --success: #10b981;
            --text-main: #f8fafc;
            --text-muted: #94a3b8;
        }

        body {
            background-color: var(--bg-dark);
            color: var(--text-main);
            font-family: 'Outfit', sans-serif;
            margin: 0;
            padding: 0;
            display: flex;
            flex-direction: column;
            min-height: 100vh;
        }

        header {
            background: var(--surface);
            padding: 1.5rem 1.5rem;
            display: flex;
            justify-content: space-between;
            align-items: center;
            border-bottom: 2px solid #334155;
            box-shadow: 0 4px 15px -1px rgba(0, 0, 0, 0.5);
            position: sticky;
            top: 0;
            z-index: 10;
        }

        .driver-info h1 {
            font-size: 1.6rem;
            margin: 0;
            color: var(--primary);
            text-transform: uppercase;
            letter-spacing: 0.05em;
        }

        .driver-info p {
            margin: 0;
            color: var(--text-muted);
            font-size: 0.95rem;
            margin-top: 0.2rem;
        }

        .status-badge {
            background: rgba(16, 185, 129, 0.15);
            color: var(--success);
            padding: 0.5rem 1.2rem;
            border-radius: 20px;
            font-weight: 700;
            border: 1px solid var(--success);
            text-transform: uppercase;
            font-size: 0.85rem;
            box-shadow: 0 0 10px rgba(16, 185, 129, 0.2);
        }

        .container {
            padding: 1.5rem;
            flex: 1;
            max-width: 600px;
            margin: 0 auto;
            width: 100%;
        }

        .stat-grid {
            display: grid;
            grid-template-columns: 1fr 1fr;
            gap: 1rem;
            margin-bottom: 2rem;
        }

        .stat-card {
            background: var(--surface);
            padding: 1.5rem 1rem;
            border-radius: 16px;
            text-align: center;
            border: 1px solid #334155;
            box-shadow: 0 4px 6px rgba(0,0,0,0.1);
        }

        .stat-value {
            font-size: 2.5rem;
            font-weight: 700;
            margin-bottom: 0.3rem;
            color: var(--text-main);
        }

        .stat-label {
            color: var(--text-muted);
            font-size: 0.85rem;
            text-transform: uppercase;
            letter-spacing: 0.1em;
            font-weight: 600;
        }

        .next-stop-card {
            background: linear-gradient(145deg, var(--surface), #151e2b);
            border-radius: 16px;
            padding: 1.8rem;
            margin-bottom: 2rem;
            border: 1px solid var(--primary);
            box-shadow: 0 10px 25px -5px rgba(245, 158, 11, 0.15);
            position: relative;
            overflow: hidden;
        }
        
        .next-stop-card::before {
            content: '';
            position: absolute;
            top: 0; left: 0; height: 100%; width: 4px;
            background: var(--primary);
        }

        .next-stop-card h3 {
            color: var(--primary);
            margin: 0 0 0.5rem 0;
            text-transform: uppercase;
            font-size: 0.9rem;
            letter-spacing: 0.1em;
        }

        .stop-name {
            font-size: 2.2rem;
            font-weight: 700;
            margin-bottom: 0.8rem;
            line-height: 1.1;
        }

        .stop-time {
            color: var(--text-muted);
            font-size: 1.1rem;
            display: flex;
            align-items: center;
            gap: 0.5rem;
            background: rgba(0,0,0,0.2);
            padding: 0.5rem 1rem;
            border-radius: 8px;
            display: inline-block;
        }

        .actions {
            display: flex;
            gap: 1rem;
            flex-direction: column;
        }

        .btn {
            width: 100%;
            padding: 1.2rem;
            font-size: 1.2rem;
            font-weight: 700;
            border: none;
            border-radius: 12px;
            cursor: pointer;
            transition: all 0.2s;
            text-transform: uppercase;
            letter-spacing: 0.05em;
            display: flex;
            justify-content: center;
            align-items: center;
            gap: 10px;
        }

        .btn:active {
            transform: scale(0.98);
        }

        .btn-primary {
            background: var(--primary);
            color: var(--bg-dark);
            box-shadow: 0 6px 15px rgba(245, 158, 11, 0.3);
        }

        .btn-primary:hover {
            background: var(--primary-hover);
        }

        .btn-danger {
            background: transparent;
            color: var(--danger);
            border: 2px solid var(--danger);
        }

        .activity-feed {
            margin-top: 2.5rem;
        }
        
        .activity-feed h3 {
            color: var(--text-muted);
            font-size: 1rem;
            border-bottom: 1px solid #334155;
            padding-bottom: 0.8rem;
            margin-bottom: 0;
            text-transform: uppercase;
            letter-spacing: 0.05em;
        }

        .feed-item {
            display: flex;
            justify-content: space-between;
            padding: 1.2rem 0;
            border-bottom: 1px solid #334155;
            font-size: 1.05rem;
            animation: fadeIn 0.4s ease;
        }
        
        @keyframes fadeIn {
            from { opacity: 0; transform: translateX(-10px); }
            to { opacity: 1; transform: translateX(0); }
        }
    """

    let driverJs = """
        let passengers = 12;

        function updatePassengerCount() {
            document.getElementById('passengerCount').innerText = passengers;
            document.getElementById('passengerCountCard').style.transform = 'scale(1.1)';
            setTimeout(() => {
                document.getElementById('passengerCountCard').style.transform = 'scale(1)';
            }, 200);
        }

        function departStop() {
            const btn = document.getElementById('departBtn');
            btn.innerText = "Transit...";
            btn.style.background = "#334155";
            btn.style.color = "white";
            btn.style.boxShadow = "none";
            
            setTimeout(() => {
                document.getElementById('currentStopName').innerText = "Night Market";
                document.getElementById('stopTime').innerText = "ETA: 14:15";
                
                btn.innerHTML = `<svg width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><path d="M22 11.08V12a10 10 0 1 1-5.93-9.14"></path><polyline points="22 4 12 14.01 9 11.01"></polyline></svg> Arrive at Stop`;
                btn.style.background = "var(--primary)";
                btn.style.color = "var(--bg-dark)";
                btn.style.boxShadow = "0 6px 15px rgba(245, 158, 11, 0.3)";
                btn.onclick = arriveStop;
                
                logActivity("Departed Airport");
            }, 1000);
        }

        function arriveStop() {
            const btn = document.getElementById('departBtn');
            document.getElementById('currentStopName').innerText = "Night Market (Arrived)";
            btn.innerText = "Depart to Kuang Si";
            btn.onclick = departStopFinal;
            
            // Simulate passengers boarding
            let boarding = Math.floor(Math.random() * 6) + 1;
            passengers += boarding;
            updatePassengerCount();
            
            logActivity(`Arrived. +${boarding} boarding.`);
        }

        function departStopFinal() {
            alert('End of simulated route for prototype.');
        }

        function logActivity(msg) {
            const feed = document.getElementById('feedList');
            const time = new Date().toLocaleTimeString([], {hour: '2-digit', minute:'2-digit'});
            feed.insertAdjacentHTML('afterbegin', `<div class="feed-item"><span>${msg}</span><span style="color:var(--text-muted)">${time}</span></div>`);
        }
    """

    let driverView =
        html [ _lang "en" ] [
            head [] [
                meta [ _charset "UTF-8" ]
                meta [ _name "viewport"; _content "width=device-width, initial-scale=1.0" ]
                title [] [ str "Driver Terminal - LpbGO" ]
                style [] [ rawText driverCss ]
            ]
            body [] [
                header [] [
                    div [ _class "driver-info" ] [
                        h1 [] [ str "Bus #42" ]
                        p [] [ str "Route: Airport -> Kuang Si" ]
                    ]
                    div [ _class "status-badge" ] [ str "ON DUTY" ]
                ]
                
                div [ _class "container" ] [
                    div [ _class "stat-grid" ] [
                        div [ _class "stat-card"; _id "passengerCountCard"; _style "transition: transform 0.2s ease;" ] [
                            div [ _class "stat-value"; _id "passengerCount" ] [ str "12" ]
                            div [ _class "stat-label" ] [ str "Passengers" ]
                        ]
                        div [ _class "stat-card" ] [
                            div [ _class "stat-value"; _style "color: var(--success);" ] [ str "On Time" ]
                            div [ _class "stat-label" ] [ str "Status" ]
                        ]
                    ]

                    div [ _class "next-stop-card" ] [
                        h3 [] [ str "Current / Next Stop" ]
                        div [ _class "stop-name"; _id "currentStopName" ] [ str "Intl. Airport" ]
                        div [ _class "stop-time"; _id "stopTime" ] [ str "Departure: 14:00" ]
                    ]

                    div [ _class "actions" ] [
                        button [ _id "departBtn"; _class "btn btn-primary"; _onclick "departStop()" ] [ 
                            rawText """<svg width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><circle cx="12" cy="12" r="10"></circle><polyline points="12 6 12 12 16 14"></polyline></svg> """
                            str "Start Route" 
                        ]
                        button [ _class "btn btn-danger"; _onclick "alert('Emergency dispatched to HQ')" ] [ str "SOS Alert HQ" ]
                    ]

                    div [ _class "activity-feed" ] [
                        h3 [] [ str "Recent Activity" ]
                        div [ _id "feedList" ] [
                            div [ _class "feed-item" ] [
                                span [] [ str "Shift Started" ]
                                span [ _style "color:var(--text-muted)" ] [ str "13:45" ]
                            ]
                        ]
                    ]
                ]
                script [] [ rawText driverJs ]
            ]
        ]

module AuthViews =
    
    let authCss = """
        @import url('https://fonts.googleapis.com/css2?family=Outfit:wght@300;400;600;700&display=swap');

        :root {
            --bg-color: #0f172a;
            --glass-bg: rgba(30, 41, 59, 0.7);
            --glass-border: rgba(255, 255, 255, 0.1);
            --primary: #10b981;
            --primary-hover: #059669;
            --text-main: #f8fafc;
            --text-muted: #94a3b8;
            --danger: #ef4444;
        }

        * { box-sizing: border-box; margin: 0; padding: 0; font-family: 'Outfit', sans-serif; }

        body {
            background-color: var(--bg-color);
            background-image: radial-gradient(circle at top right, #1e293b, #0f172a);
            color: var(--text-main);
            min-height: 100vh;
            display: flex;
            align-items: center;
            justify-content: center;
            padding: 2rem;
        }

        .auth-container {
            width: 100%;
            max-width: 400px;
            background: var(--glass-bg);
            backdrop-filter: blur(12px);
            border: 1px solid var(--glass-border);
            border-radius: 24px;
            padding: 2.5rem;
            box-shadow: 0 25px 50px -12px rgba(0, 0, 0, 0.5);
            text-align: center;
        }

        .auth-container h2 {
            font-size: 2rem;
            margin-bottom: 0.5rem;
            color: var(--primary);
        }

        .auth-container p {
            color: var(--text-muted);
            margin-bottom: 2rem;
        }

        .form-group {
            margin-bottom: 1.5rem;
            text-align: left;
        }

        label {
            display: block;
            margin-bottom: 0.5rem;
            color: var(--text-muted);
            font-size: 0.9rem;
            text-transform: uppercase;
        }

        input {
            width: 100%;
            padding: 1rem;
            border-radius: 12px;
            background: rgba(15, 23, 42, 0.8);
            border: 1px solid var(--glass-border);
            color: white;
            font-size: 1rem;
            outline: none;
            transition: all 0.3s;
        }

        input:focus {
            border-color: var(--primary);
            box-shadow: 0 0 0 3px rgba(16, 185, 129, 0.2);
        }

        button {
            width: 100%;
            padding: 1.2rem;
            background: var(--primary);
            color: white;
            border: none;
            border-radius: 12px;
            font-size: 1.1rem;
            font-weight: 600;
            cursor: pointer;
            transition: all 0.3s;
            margin-top: 1rem;
        }

        button:hover {
            background: var(--primary-hover);
            transform: translateY(-2px);
            box-shadow: 0 10px 20px -10px var(--primary);
        }

        .link-text {
            margin-top: 1.5rem;
            color: var(--text-muted);
            font-size: 0.95rem;
        }

        .link-text a {
            color: var(--primary);
            text-decoration: none;
            font-weight: 600;
        }

        .error-message {
            color: var(--danger);
            background: rgba(239, 68, 68, 0.1);
            padding: 1rem;
            border-radius: 8px;
            margin-bottom: 1.5rem;
            border: 1px solid rgba(239, 68, 68, 0.3);
            text-align: left;
        }
    """

    let inline createView titleText subtitleText actionUrl btnText bottomText bottomLinkText bottomUrl error =
        html [ _lang "en" ] [
            head [] [
                meta [ _charset "UTF-8" ]
                meta [ _name "viewport"; _content "width=device-width, initial-scale=1.0" ]
                title [] [ str (titleText + " | LpbGO") ]
                style [] [ rawText authCss ]
            ]
            body [] [
                div [ _class "auth-container" ] [
                    h2 [] [ str titleText ]
                    p [] [ str subtitleText ]
                    
                    if not (System.String.IsNullOrEmpty(error)) then
                        div [ _class "error-message" ] [ str error ]
                        
                    form [ _action actionUrl; _method "POST" ] [
                        div [ _class "form-group" ] [
                            label [ _for "Username" ] [ str "Username" ]
                            input [ _type "text"; _id "Username"; _name "Username"; _required ]
                        ]
                        div [ _class "form-group" ] [
                            label [ _for "Password" ] [ str "Password" ]
                            input [ _type "password"; _id "Password"; _name "Password"; _required ]
                        ]
                        button [ _type "submit" ] [ str btnText ]
                    ]
                    div [ _class "link-text" ] [
                        span [] [ str bottomText ]
                        a [ _href bottomUrl ] [ str bottomLinkText ]
                    ]
                ]
            ]
        ]
        
    let loginView error = createView "Welcome Back" "Log in to your LpbGO account" "/auth/login" "Log In" "Don't have an account? " "Sign Up" "/auth/login" error
    
    let registerView error = createView "Create Account" "Join LpbGO to easily manage your tickets" "/auth/register" "Sign Up" "Already have an account? " "Log In" "/auth/login" error
