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
using Amazon.DirectConnect;
using Amazon.DirectConnect.Model;

namespace Amazon.PowerShell.Cmdlets.DC
{
    /// <summary>
    /// Updates the attributes of the specified link aggregation group (LAG).
    /// 
    ///  
    /// <para>
    /// You can update the following LAG attributes:
    /// </para><ul><li><para>
    /// The name of the LAG.
    /// </para></li><li><para>
    /// The value for the minimum number of connections that must be operational for the LAG
    /// itself to be operational. 
    /// </para></li><li><para>
    /// The LAG's MACsec encryption mode.
    /// </para><para>
    /// Amazon Web Services assigns this value to each connection which is part of the LAG.
    /// </para></li><li><para>
    /// The tags
    /// </para></li></ul><note><para>
    /// If you adjust the threshold value for the minimum number of operational connections,
    /// ensure that the new value does not cause the LAG to fall below the threshold and become
    /// non-operational.
    /// </para></note>
    /// </summary>
    [Cmdlet("Update", "DCLag", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DirectConnect.Model.UpdateLagResponse")]
    [AWSCmdlet("Calls the AWS Direct Connect UpdateLag API operation.", Operation = new[] {"UpdateLag"}, SelectReturnType = typeof(Amazon.DirectConnect.Model.UpdateLagResponse))]
    [AWSCmdletOutput("Amazon.DirectConnect.Model.UpdateLagResponse",
        "This cmdlet returns an Amazon.DirectConnect.Model.UpdateLagResponse object containing multiple properties."
    )]
    public partial class UpdateDCLagCmdlet : AmazonDirectConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter EncryptionMode
        /// <summary>
        /// <para>
        /// <para>The LAG MAC Security (MACsec) encryption mode.</para><para>Amazon Web Services applies the value to all connections which are part of the LAG.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EncryptionMode { get; set; }
        #endregion
        
        #region Parameter LagId
        /// <summary>
        /// <para>
        /// <para>The ID of the LAG.</para>
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
        public System.String LagId { get; set; }
        #endregion
        
        #region Parameter LagName
        /// <summary>
        /// <para>
        /// <para>The name of the LAG.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LagName { get; set; }
        #endregion
        
        #region Parameter MinimumLink
        /// <summary>
        /// <para>
        /// <para>The minimum number of physical connections that must be operational for the LAG itself
        /// to be operational.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MinimumLinks")]
        public System.Int32? MinimumLink { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DirectConnect.Model.UpdateLagResponse).
        /// Specifying the name of a property of type Amazon.DirectConnect.Model.UpdateLagResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.LagId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-DCLag (UpdateLag)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DirectConnect.Model.UpdateLagResponse, UpdateDCLagCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.EncryptionMode = this.EncryptionMode;
            context.LagId = this.LagId;
            #if MODULAR
            if (this.LagId == null && ParameterWasBound(nameof(this.LagId)))
            {
                WriteWarning("You are passing $null as a value for parameter LagId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LagName = this.LagName;
            context.MinimumLink = this.MinimumLink;
            
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
            var request = new Amazon.DirectConnect.Model.UpdateLagRequest();
            
            if (cmdletContext.EncryptionMode != null)
            {
                request.EncryptionMode = cmdletContext.EncryptionMode;
            }
            if (cmdletContext.LagId != null)
            {
                request.LagId = cmdletContext.LagId;
            }
            if (cmdletContext.LagName != null)
            {
                request.LagName = cmdletContext.LagName;
            }
            if (cmdletContext.MinimumLink != null)
            {
                request.MinimumLinks = cmdletContext.MinimumLink.Value;
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
        
        private Amazon.DirectConnect.Model.UpdateLagResponse CallAWSServiceOperation(IAmazonDirectConnect client, Amazon.DirectConnect.Model.UpdateLagRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Direct Connect", "UpdateLag");
            try
            {
                #if DESKTOP
                return client.UpdateLag(request);
                #elif CORECLR
                return client.UpdateLagAsync(request).GetAwaiter().GetResult();
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
            public System.String EncryptionMode { get; set; }
            public System.String LagId { get; set; }
            public System.String LagName { get; set; }
            public System.Int32? MinimumLink { get; set; }
            public System.Func<Amazon.DirectConnect.Model.UpdateLagResponse, UpdateDCLagCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
