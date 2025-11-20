/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.NetworkManager;
using Amazon.NetworkManager.Model;

namespace Amazon.PowerShell.Cmdlets.NMGR
{
    /// <summary>
    /// Creates an association between a core network and a prefix list for routing control.
    /// </summary>
    [Cmdlet("New", "NMGRCoreNetworkPrefixListAssociation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.NetworkManager.Model.CreateCoreNetworkPrefixListAssociationResponse")]
    [AWSCmdlet("Calls the AWS Network Manager CreateCoreNetworkPrefixListAssociation API operation.", Operation = new[] {"CreateCoreNetworkPrefixListAssociation"}, SelectReturnType = typeof(Amazon.NetworkManager.Model.CreateCoreNetworkPrefixListAssociationResponse))]
    [AWSCmdletOutput("Amazon.NetworkManager.Model.CreateCoreNetworkPrefixListAssociationResponse",
        "This cmdlet returns an Amazon.NetworkManager.Model.CreateCoreNetworkPrefixListAssociationResponse object containing multiple properties."
    )]
    public partial class NewNMGRCoreNetworkPrefixListAssociationCmdlet : AmazonNetworkManagerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CoreNetworkId
        /// <summary>
        /// <para>
        /// <para>The ID of the core network to associate with the prefix list.</para>
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
        public System.String CoreNetworkId { get; set; }
        #endregion
        
        #region Parameter PrefixListAlias
        /// <summary>
        /// <para>
        /// <para>An optional alias for the prefix list association.</para>
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
        public System.String PrefixListAlias { get; set; }
        #endregion
        
        #region Parameter PrefixListArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the prefix list to associate with the core network.</para>
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
        public System.String PrefixListArn { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NetworkManager.Model.CreateCoreNetworkPrefixListAssociationResponse).
        /// Specifying the name of a property of type Amazon.NetworkManager.Model.CreateCoreNetworkPrefixListAssociationResponse will result in that property being returned.
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
            
            var targetParameterNames = new string[]
            {
                nameof(this.CoreNetworkId),
                nameof(this.PrefixListArn)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-NMGRCoreNetworkPrefixListAssociation (CreateCoreNetworkPrefixListAssociation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.NetworkManager.Model.CreateCoreNetworkPrefixListAssociationResponse, NewNMGRCoreNetworkPrefixListAssociationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.CoreNetworkId = this.CoreNetworkId;
            #if MODULAR
            if (this.CoreNetworkId == null && ParameterWasBound(nameof(this.CoreNetworkId)))
            {
                WriteWarning("You are passing $null as a value for parameter CoreNetworkId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PrefixListAlias = this.PrefixListAlias;
            #if MODULAR
            if (this.PrefixListAlias == null && ParameterWasBound(nameof(this.PrefixListAlias)))
            {
                WriteWarning("You are passing $null as a value for parameter PrefixListAlias which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PrefixListArn = this.PrefixListArn;
            #if MODULAR
            if (this.PrefixListArn == null && ParameterWasBound(nameof(this.PrefixListArn)))
            {
                WriteWarning("You are passing $null as a value for parameter PrefixListArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.NetworkManager.Model.CreateCoreNetworkPrefixListAssociationRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.CoreNetworkId != null)
            {
                request.CoreNetworkId = cmdletContext.CoreNetworkId;
            }
            if (cmdletContext.PrefixListAlias != null)
            {
                request.PrefixListAlias = cmdletContext.PrefixListAlias;
            }
            if (cmdletContext.PrefixListArn != null)
            {
                request.PrefixListArn = cmdletContext.PrefixListArn;
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
        
        private Amazon.NetworkManager.Model.CreateCoreNetworkPrefixListAssociationResponse CallAWSServiceOperation(IAmazonNetworkManager client, Amazon.NetworkManager.Model.CreateCoreNetworkPrefixListAssociationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Network Manager", "CreateCoreNetworkPrefixListAssociation");
            try
            {
                #if DESKTOP
                return client.CreateCoreNetworkPrefixListAssociation(request);
                #elif CORECLR
                return client.CreateCoreNetworkPrefixListAssociationAsync(request).GetAwaiter().GetResult();
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
            public System.String CoreNetworkId { get; set; }
            public System.String PrefixListAlias { get; set; }
            public System.String PrefixListArn { get; set; }
            public System.Func<Amazon.NetworkManager.Model.CreateCoreNetworkPrefixListAssociationResponse, NewNMGRCoreNetworkPrefixListAssociationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
