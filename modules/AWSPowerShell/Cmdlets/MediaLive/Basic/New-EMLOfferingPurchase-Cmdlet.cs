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
using Amazon.MediaLive;
using Amazon.MediaLive.Model;

namespace Amazon.PowerShell.Cmdlets.EML
{
    /// <summary>
    /// Purchase an offering and create a reservation.
    /// </summary>
    [Cmdlet("New", "EMLOfferingPurchase", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MediaLive.Model.Reservation")]
    [AWSCmdlet("Calls the AWS Elemental MediaLive PurchaseOffering API operation.", Operation = new[] {"PurchaseOffering"}, SelectReturnType = typeof(Amazon.MediaLive.Model.PurchaseOfferingResponse))]
    [AWSCmdletOutput("Amazon.MediaLive.Model.Reservation or Amazon.MediaLive.Model.PurchaseOfferingResponse",
        "This cmdlet returns an Amazon.MediaLive.Model.Reservation object.",
        "The service call response (type Amazon.MediaLive.Model.PurchaseOfferingResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewEMLOfferingPurchaseCmdlet : AmazonMediaLiveClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter RenewalSettings_AutomaticRenewal
        /// <summary>
        /// <para>
        /// Automatic renewal status for the reservation
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaLive.ReservationAutomaticRenewal")]
        public Amazon.MediaLive.ReservationAutomaticRenewal RenewalSettings_AutomaticRenewal { get; set; }
        #endregion
        
        #region Parameter Count
        /// <summary>
        /// <para>
        /// Number of resources
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? Count { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// Name for the new reservation
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter OfferingId
        /// <summary>
        /// <para>
        /// Offering to purchase, e.g. '87654321'
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
        public System.String OfferingId { get; set; }
        #endregion
        
        #region Parameter RenewalSettings_RenewalCount
        /// <summary>
        /// <para>
        /// Count for the reservation renewal
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? RenewalSettings_RenewalCount { get; set; }
        #endregion
        
        #region Parameter RequestId
        /// <summary>
        /// <para>
        /// Unique request ID to be specified. This is needed
        /// to prevent retries from creating multiple resources.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RequestId { get; set; }
        #endregion
        
        #region Parameter Start
        /// <summary>
        /// <para>
        /// Requested reservation start time (UTC) in ISO-8601
        /// format. The specified time must be between the first day of the current month and
        /// one year from now. If no value is given, the default is now.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Start { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// A collection of key-value pairs
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Reservation'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MediaLive.Model.PurchaseOfferingResponse).
        /// Specifying the name of a property of type Amazon.MediaLive.Model.PurchaseOfferingResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.OfferingId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EMLOfferingPurchase (PurchaseOffering)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MediaLive.Model.PurchaseOfferingResponse, NewEMLOfferingPurchaseCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Count = this.Count;
            #if MODULAR
            if (this.Count == null && ParameterWasBound(nameof(this.Count)))
            {
                WriteWarning("You are passing $null as a value for parameter Count which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            context.OfferingId = this.OfferingId;
            #if MODULAR
            if (this.OfferingId == null && ParameterWasBound(nameof(this.OfferingId)))
            {
                WriteWarning("You are passing $null as a value for parameter OfferingId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RenewalSettings_AutomaticRenewal = this.RenewalSettings_AutomaticRenewal;
            context.RenewalSettings_RenewalCount = this.RenewalSettings_RenewalCount;
            context.RequestId = this.RequestId;
            context.Start = this.Start;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            
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
            var request = new Amazon.MediaLive.Model.PurchaseOfferingRequest();
            
            if (cmdletContext.Count != null)
            {
                request.Count = cmdletContext.Count.Value;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.OfferingId != null)
            {
                request.OfferingId = cmdletContext.OfferingId;
            }
            
             // populate RenewalSettings
            var requestRenewalSettingsIsNull = true;
            request.RenewalSettings = new Amazon.MediaLive.Model.RenewalSettings();
            Amazon.MediaLive.ReservationAutomaticRenewal requestRenewalSettings_renewalSettings_AutomaticRenewal = null;
            if (cmdletContext.RenewalSettings_AutomaticRenewal != null)
            {
                requestRenewalSettings_renewalSettings_AutomaticRenewal = cmdletContext.RenewalSettings_AutomaticRenewal;
            }
            if (requestRenewalSettings_renewalSettings_AutomaticRenewal != null)
            {
                request.RenewalSettings.AutomaticRenewal = requestRenewalSettings_renewalSettings_AutomaticRenewal;
                requestRenewalSettingsIsNull = false;
            }
            System.Int32? requestRenewalSettings_renewalSettings_RenewalCount = null;
            if (cmdletContext.RenewalSettings_RenewalCount != null)
            {
                requestRenewalSettings_renewalSettings_RenewalCount = cmdletContext.RenewalSettings_RenewalCount.Value;
            }
            if (requestRenewalSettings_renewalSettings_RenewalCount != null)
            {
                request.RenewalSettings.RenewalCount = requestRenewalSettings_renewalSettings_RenewalCount.Value;
                requestRenewalSettingsIsNull = false;
            }
             // determine if request.RenewalSettings should be set to null
            if (requestRenewalSettingsIsNull)
            {
                request.RenewalSettings = null;
            }
            if (cmdletContext.RequestId != null)
            {
                request.RequestId = cmdletContext.RequestId;
            }
            if (cmdletContext.Start != null)
            {
                request.Start = cmdletContext.Start;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.MediaLive.Model.PurchaseOfferingResponse CallAWSServiceOperation(IAmazonMediaLive client, Amazon.MediaLive.Model.PurchaseOfferingRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaLive", "PurchaseOffering");
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
            public System.Int32? Count { get; set; }
            public System.String Name { get; set; }
            public System.String OfferingId { get; set; }
            public Amazon.MediaLive.ReservationAutomaticRenewal RenewalSettings_AutomaticRenewal { get; set; }
            public System.Int32? RenewalSettings_RenewalCount { get; set; }
            public System.String RequestId { get; set; }
            public System.String Start { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.MediaLive.Model.PurchaseOfferingResponse, NewEMLOfferingPurchaseCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Reservation;
        }
        
    }
}
