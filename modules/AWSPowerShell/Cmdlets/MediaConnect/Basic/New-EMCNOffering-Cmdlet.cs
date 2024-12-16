/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.MediaConnect;
using Amazon.MediaConnect.Model;

namespace Amazon.PowerShell.Cmdlets.EMCN
{
    /// <summary>
    /// Submits a request to purchase an offering. If you already have an active reservation,
    /// you can't purchase another offering.
    /// </summary>
    [Cmdlet("New", "EMCNOffering", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MediaConnect.Model.Reservation")]
    [AWSCmdlet("Calls the AWS Elemental MediaConnect PurchaseOffering API operation.", Operation = new[] {"PurchaseOffering"}, SelectReturnType = typeof(Amazon.MediaConnect.Model.PurchaseOfferingResponse))]
    [AWSCmdletOutput("Amazon.MediaConnect.Model.Reservation or Amazon.MediaConnect.Model.PurchaseOfferingResponse",
        "This cmdlet returns an Amazon.MediaConnect.Model.Reservation object.",
        "The service call response (type Amazon.MediaConnect.Model.PurchaseOfferingResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewEMCNOfferingCmdlet : AmazonMediaConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter OfferingArn
        /// <summary>
        /// <para>
        /// The Amazon Resource Name (ARN) of the offering.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String OfferingArn { get; set; }
        #endregion
        
        #region Parameter ReservationName
        /// <summary>
        /// <para>
        /// The name that you want to use for the
        /// reservation.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ReservationName { get; set; }
        #endregion
        
        #region Parameter Start
        /// <summary>
        /// <para>
        /// The date and time that you want the reservation
        /// to begin, in Coordinated Universal Time (UTC). You can specify any date and time between
        /// 12:00am on the first day of the current month to the current time on today's date,
        /// inclusive. Specify the start in a 24-hour notation. Use the following format: YYYY-MM-DDTHH:mm:SSZ,
        /// where T and Z are literal characters. For example, to specify 11:30pm on March 5,
        /// 2020, enter 2020-03-05T23:30:00Z.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Start { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Reservation'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MediaConnect.Model.PurchaseOfferingResponse).
        /// Specifying the name of a property of type Amazon.MediaConnect.Model.PurchaseOfferingResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Reservation";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.OfferingArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EMCNOffering (PurchaseOffering)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MediaConnect.Model.PurchaseOfferingResponse, NewEMCNOfferingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.OfferingArn = this.OfferingArn;
            #if MODULAR
            if (this.OfferingArn == null && ParameterWasBound(nameof(this.OfferingArn)))
            {
                WriteWarning("You are passing $null as a value for parameter OfferingArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ReservationName = this.ReservationName;
            #if MODULAR
            if (this.ReservationName == null && ParameterWasBound(nameof(this.ReservationName)))
            {
                WriteWarning("You are passing $null as a value for parameter ReservationName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Start = this.Start;
            #if MODULAR
            if (this.Start == null && ParameterWasBound(nameof(this.Start)))
            {
                WriteWarning("You are passing $null as a value for parameter Start which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.MediaConnect.Model.PurchaseOfferingRequest();
            
            if (cmdletContext.OfferingArn != null)
            {
                request.OfferingArn = cmdletContext.OfferingArn;
            }
            if (cmdletContext.ReservationName != null)
            {
                request.ReservationName = cmdletContext.ReservationName;
            }
            if (cmdletContext.Start != null)
            {
                request.Start = cmdletContext.Start;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.MediaConnect.Model.PurchaseOfferingResponse CallAWSServiceOperation(IAmazonMediaConnect client, Amazon.MediaConnect.Model.PurchaseOfferingRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaConnect", "PurchaseOffering");
            try
            {
                #if DESKTOP
                return client.PurchaseOffering(request);
                #elif CORECLR
                return client.PurchaseOfferingAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String OfferingArn { get; set; }
            public System.String ReservationName { get; set; }
            public System.String Start { get; set; }
            public System.Func<Amazon.MediaConnect.Model.PurchaseOfferingResponse, NewEMCNOfferingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Reservation;
        }
        
    }
}
