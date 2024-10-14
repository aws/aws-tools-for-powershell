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
    /// Creates a subsscription grant in Amazon DataZone.
    /// </summary>
    [Cmdlet("New", "DZSubscriptionGrant", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DataZone.Model.CreateSubscriptionGrantResponse")]
    [AWSCmdlet("Calls the Amazon DataZone CreateSubscriptionGrant API operation.", Operation = new[] {"CreateSubscriptionGrant"}, SelectReturnType = typeof(Amazon.DataZone.Model.CreateSubscriptionGrantResponse))]
    [AWSCmdletOutput("Amazon.DataZone.Model.CreateSubscriptionGrantResponse",
        "This cmdlet returns an Amazon.DataZone.Model.CreateSubscriptionGrantResponse object containing multiple properties."
    )]
    public partial class NewDZSubscriptionGrantCmdlet : AmazonDataZoneClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AssetTargetName
        /// <summary>
        /// <para>
        /// <para>The names of the assets for which the subscription grant is created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AssetTargetNames")]
        public Amazon.DataZone.Model.AssetTargetNameMap[] AssetTargetName { get; set; }
        #endregion
        
        #region Parameter DomainIdentifier
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon DataZone domain in which the subscription grant is created.</para>
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
        public System.String DomainIdentifier { get; set; }
        #endregion
        
        #region Parameter EnvironmentIdentifier
        /// <summary>
        /// <para>
        /// <para>The ID of the environment in which the subscription grant is created.</para>
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
        public System.String EnvironmentIdentifier { get; set; }
        #endregion
        
        #region Parameter Listing_Identifier
        /// <summary>
        /// <para>
        /// <para>An identifier of revision to be made to an asset published in a Amazon DataZone catalog.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GrantedEntity_Listing_Identifier")]
        public System.String Listing_Identifier { get; set; }
        #endregion
        
        #region Parameter Listing_Revision
        /// <summary>
        /// <para>
        /// <para>The details of a revision to be made to an asset published in a Amazon DataZone catalog.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GrantedEntity_Listing_Revision")]
        public System.String Listing_Revision { get; set; }
        #endregion
        
        #region Parameter SubscriptionTargetIdentifier
        /// <summary>
        /// <para>
        /// <para>The ID of the subscription target for which the subscription grant is created.</para>
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
        public System.String SubscriptionTargetIdentifier { get; set; }
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DataZone.Model.CreateSubscriptionGrantResponse).
        /// Specifying the name of a property of type Amazon.DataZone.Model.CreateSubscriptionGrantResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the SubscriptionTargetIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^SubscriptionTargetIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^SubscriptionTargetIdentifier' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SubscriptionTargetIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DZSubscriptionGrant (CreateSubscriptionGrant)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DataZone.Model.CreateSubscriptionGrantResponse, NewDZSubscriptionGrantCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.SubscriptionTargetIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AssetTargetName != null)
            {
                context.AssetTargetName = new List<Amazon.DataZone.Model.AssetTargetNameMap>(this.AssetTargetName);
            }
            context.ClientToken = this.ClientToken;
            context.DomainIdentifier = this.DomainIdentifier;
            #if MODULAR
            if (this.DomainIdentifier == null && ParameterWasBound(nameof(this.DomainIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EnvironmentIdentifier = this.EnvironmentIdentifier;
            #if MODULAR
            if (this.EnvironmentIdentifier == null && ParameterWasBound(nameof(this.EnvironmentIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter EnvironmentIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Listing_Identifier = this.Listing_Identifier;
            context.Listing_Revision = this.Listing_Revision;
            context.SubscriptionTargetIdentifier = this.SubscriptionTargetIdentifier;
            #if MODULAR
            if (this.SubscriptionTargetIdentifier == null && ParameterWasBound(nameof(this.SubscriptionTargetIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter SubscriptionTargetIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.DataZone.Model.CreateSubscriptionGrantRequest();
            
            if (cmdletContext.AssetTargetName != null)
            {
                request.AssetTargetNames = cmdletContext.AssetTargetName;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DomainIdentifier != null)
            {
                request.DomainIdentifier = cmdletContext.DomainIdentifier;
            }
            if (cmdletContext.EnvironmentIdentifier != null)
            {
                request.EnvironmentIdentifier = cmdletContext.EnvironmentIdentifier;
            }
            
             // populate GrantedEntity
            var requestGrantedEntityIsNull = true;
            request.GrantedEntity = new Amazon.DataZone.Model.GrantedEntityInput();
            Amazon.DataZone.Model.ListingRevisionInput requestGrantedEntity_grantedEntity_Listing = null;
            
             // populate Listing
            var requestGrantedEntity_grantedEntity_ListingIsNull = true;
            requestGrantedEntity_grantedEntity_Listing = new Amazon.DataZone.Model.ListingRevisionInput();
            System.String requestGrantedEntity_grantedEntity_Listing_listing_Identifier = null;
            if (cmdletContext.Listing_Identifier != null)
            {
                requestGrantedEntity_grantedEntity_Listing_listing_Identifier = cmdletContext.Listing_Identifier;
            }
            if (requestGrantedEntity_grantedEntity_Listing_listing_Identifier != null)
            {
                requestGrantedEntity_grantedEntity_Listing.Identifier = requestGrantedEntity_grantedEntity_Listing_listing_Identifier;
                requestGrantedEntity_grantedEntity_ListingIsNull = false;
            }
            System.String requestGrantedEntity_grantedEntity_Listing_listing_Revision = null;
            if (cmdletContext.Listing_Revision != null)
            {
                requestGrantedEntity_grantedEntity_Listing_listing_Revision = cmdletContext.Listing_Revision;
            }
            if (requestGrantedEntity_grantedEntity_Listing_listing_Revision != null)
            {
                requestGrantedEntity_grantedEntity_Listing.Revision = requestGrantedEntity_grantedEntity_Listing_listing_Revision;
                requestGrantedEntity_grantedEntity_ListingIsNull = false;
            }
             // determine if requestGrantedEntity_grantedEntity_Listing should be set to null
            if (requestGrantedEntity_grantedEntity_ListingIsNull)
            {
                requestGrantedEntity_grantedEntity_Listing = null;
            }
            if (requestGrantedEntity_grantedEntity_Listing != null)
            {
                request.GrantedEntity.Listing = requestGrantedEntity_grantedEntity_Listing;
                requestGrantedEntityIsNull = false;
            }
             // determine if request.GrantedEntity should be set to null
            if (requestGrantedEntityIsNull)
            {
                request.GrantedEntity = null;
            }
            if (cmdletContext.SubscriptionTargetIdentifier != null)
            {
                request.SubscriptionTargetIdentifier = cmdletContext.SubscriptionTargetIdentifier;
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
        
        private Amazon.DataZone.Model.CreateSubscriptionGrantResponse CallAWSServiceOperation(IAmazonDataZone client, Amazon.DataZone.Model.CreateSubscriptionGrantRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DataZone", "CreateSubscriptionGrant");
            try
            {
                #if DESKTOP
                return client.CreateSubscriptionGrant(request);
                #elif CORECLR
                return client.CreateSubscriptionGrantAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.DataZone.Model.AssetTargetNameMap> AssetTargetName { get; set; }
            public System.String ClientToken { get; set; }
            public System.String DomainIdentifier { get; set; }
            public System.String EnvironmentIdentifier { get; set; }
            public System.String Listing_Identifier { get; set; }
            public System.String Listing_Revision { get; set; }
            public System.String SubscriptionTargetIdentifier { get; set; }
            public System.Func<Amazon.DataZone.Model.CreateSubscriptionGrantResponse, NewDZSubscriptionGrantCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
