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
using Amazon.DataZone;
using Amazon.DataZone.Model;

namespace Amazon.PowerShell.Cmdlets.DZ
{
    /// <summary>
    /// Creates a subscription request in Amazon DataZone.
    /// </summary>
    [Cmdlet("New", "DZSubscriptionRequest", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DataZone.Model.CreateSubscriptionRequestResponse")]
    [AWSCmdlet("Calls the Amazon DataZone CreateSubscriptionRequest API operation.", Operation = new[] {"CreateSubscriptionRequest"}, SelectReturnType = typeof(Amazon.DataZone.Model.CreateSubscriptionRequestResponse))]
    [AWSCmdletOutput("Amazon.DataZone.Model.CreateSubscriptionRequestResponse",
        "This cmdlet returns an Amazon.DataZone.Model.CreateSubscriptionRequestResponse object containing multiple properties."
    )]
    public partial class NewDZSubscriptionRequestCmdlet : AmazonDataZoneClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DomainIdentifier
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon DataZone domain in which the subscription request is created.</para>
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
        public System.String DomainIdentifier { get; set; }
        #endregion
        
        #region Parameter MetadataForm
        /// <summary>
        /// <para>
        /// <para>The metadata form included in the subscription request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetadataForms")]
        public Amazon.DataZone.Model.FormInput[] MetadataForm { get; set; }
        #endregion
        
        #region Parameter RequestReason
        /// <summary>
        /// <para>
        /// <para>The reason for the subscription request.</para>
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
        public System.String RequestReason { get; set; }
        #endregion
        
        #region Parameter SubscribedListing
        /// <summary>
        /// <para>
        /// <para>The published asset for which the subscription grant is to be created.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("SubscribedListings")]
        public Amazon.DataZone.Model.SubscribedListingInput[] SubscribedListing { get; set; }
        #endregion
        
        #region Parameter SubscribedPrincipal
        /// <summary>
        /// <para>
        /// <para>The Amazon DataZone principals for whom the subscription request is created.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("SubscribedPrincipals")]
        public Amazon.DataZone.Model.SubscribedPrincipalInput[] SubscribedPrincipal { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that is provided to ensure the idempotency of
        /// the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DataZone.Model.CreateSubscriptionRequestResponse).
        /// Specifying the name of a property of type Amazon.DataZone.Model.CreateSubscriptionRequestResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DomainIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DZSubscriptionRequest (CreateSubscriptionRequest)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DataZone.Model.CreateSubscriptionRequestResponse, NewDZSubscriptionRequestCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.DomainIdentifier = this.DomainIdentifier;
            #if MODULAR
            if (this.DomainIdentifier == null && ParameterWasBound(nameof(this.DomainIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.MetadataForm != null)
            {
                context.MetadataForm = new List<Amazon.DataZone.Model.FormInput>(this.MetadataForm);
            }
            context.RequestReason = this.RequestReason;
            #if MODULAR
            if (this.RequestReason == null && ParameterWasBound(nameof(this.RequestReason)))
            {
                WriteWarning("You are passing $null as a value for parameter RequestReason which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.SubscribedListing != null)
            {
                context.SubscribedListing = new List<Amazon.DataZone.Model.SubscribedListingInput>(this.SubscribedListing);
            }
            #if MODULAR
            if (this.SubscribedListing == null && ParameterWasBound(nameof(this.SubscribedListing)))
            {
                WriteWarning("You are passing $null as a value for parameter SubscribedListing which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.SubscribedPrincipal != null)
            {
                context.SubscribedPrincipal = new List<Amazon.DataZone.Model.SubscribedPrincipalInput>(this.SubscribedPrincipal);
            }
            #if MODULAR
            if (this.SubscribedPrincipal == null && ParameterWasBound(nameof(this.SubscribedPrincipal)))
            {
                WriteWarning("You are passing $null as a value for parameter SubscribedPrincipal which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.DataZone.Model.CreateSubscriptionRequestRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DomainIdentifier != null)
            {
                request.DomainIdentifier = cmdletContext.DomainIdentifier;
            }
            if (cmdletContext.MetadataForm != null)
            {
                request.MetadataForms = cmdletContext.MetadataForm;
            }
            if (cmdletContext.RequestReason != null)
            {
                request.RequestReason = cmdletContext.RequestReason;
            }
            if (cmdletContext.SubscribedListing != null)
            {
                request.SubscribedListings = cmdletContext.SubscribedListing;
            }
            if (cmdletContext.SubscribedPrincipal != null)
            {
                request.SubscribedPrincipals = cmdletContext.SubscribedPrincipal;
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
        
        private Amazon.DataZone.Model.CreateSubscriptionRequestResponse CallAWSServiceOperation(IAmazonDataZone client, Amazon.DataZone.Model.CreateSubscriptionRequestRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DataZone", "CreateSubscriptionRequest");
            try
            {
                #if DESKTOP
                return client.CreateSubscriptionRequest(request);
                #elif CORECLR
                return client.CreateSubscriptionRequestAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String DomainIdentifier { get; set; }
            public List<Amazon.DataZone.Model.FormInput> MetadataForm { get; set; }
            public System.String RequestReason { get; set; }
            public List<Amazon.DataZone.Model.SubscribedListingInput> SubscribedListing { get; set; }
            public List<Amazon.DataZone.Model.SubscribedPrincipalInput> SubscribedPrincipal { get; set; }
            public System.Func<Amazon.DataZone.Model.CreateSubscriptionRequestResponse, NewDZSubscriptionRequestCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
