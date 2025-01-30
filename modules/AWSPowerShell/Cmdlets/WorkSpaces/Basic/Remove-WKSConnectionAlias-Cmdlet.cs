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
using Amazon.WorkSpaces;
using Amazon.WorkSpaces.Model;

namespace Amazon.PowerShell.Cmdlets.WKS
{
    /// <summary>
    /// Deletes the specified connection alias. For more information, see <a href="https://docs.aws.amazon.com/workspaces/latest/adminguide/cross-region-redirection.html">
    /// Cross-Region Redirection for Amazon WorkSpaces</a>.
    /// 
    ///  <important><para><b>If you will no longer be using a fully qualified domain name (FQDN) as the registration
    /// code for your WorkSpaces users, you must take certain precautions to prevent potential
    /// security issues.</b> For more information, see <a href="https://docs.aws.amazon.com/workspaces/latest/adminguide/cross-region-redirection.html#cross-region-redirection-security-considerations">
    /// Security Considerations if You Stop Using Cross-Region Redirection</a>.
    /// </para></important><note><para>
    /// To delete a connection alias that has been shared, the shared account must first disassociate
    /// the connection alias from any directories it has been associated with. Then you must
    /// unshare the connection alias from the account it has been shared with. You can delete
    /// a connection alias only after it is no longer shared with any accounts or associated
    /// with any directories.
    /// </para></note>
    /// </summary>
    [Cmdlet("Remove", "WKSConnectionAlias", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon WorkSpaces DeleteConnectionAlias API operation.", Operation = new[] {"DeleteConnectionAlias"}, SelectReturnType = typeof(Amazon.WorkSpaces.Model.DeleteConnectionAliasResponse))]
    [AWSCmdletOutput("None or Amazon.WorkSpaces.Model.DeleteConnectionAliasResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.WorkSpaces.Model.DeleteConnectionAliasResponse) be returned by specifying '-Select *'."
    )]
    public partial class RemoveWKSConnectionAliasCmdlet : AmazonWorkSpacesClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AliasId
        /// <summary>
        /// <para>
        /// <para>The identifier of the connection alias to delete.</para>
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
        public System.String AliasId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WorkSpaces.Model.DeleteConnectionAliasResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AliasId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AliasId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AliasId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AliasId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-WKSConnectionAlias (DeleteConnectionAlias)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WorkSpaces.Model.DeleteConnectionAliasResponse, RemoveWKSConnectionAliasCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AliasId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AliasId = this.AliasId;
            #if MODULAR
            if (this.AliasId == null && ParameterWasBound(nameof(this.AliasId)))
            {
                WriteWarning("You are passing $null as a value for parameter AliasId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.WorkSpaces.Model.DeleteConnectionAliasRequest();
            
            if (cmdletContext.AliasId != null)
            {
                request.AliasId = cmdletContext.AliasId;
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
        
        private Amazon.WorkSpaces.Model.DeleteConnectionAliasResponse CallAWSServiceOperation(IAmazonWorkSpaces client, Amazon.WorkSpaces.Model.DeleteConnectionAliasRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon WorkSpaces", "DeleteConnectionAlias");
            try
            {
                #if DESKTOP
                return client.DeleteConnectionAlias(request);
                #elif CORECLR
                return client.DeleteConnectionAliasAsync(request).GetAwaiter().GetResult();
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
            public System.String AliasId { get; set; }
            public System.Func<Amazon.WorkSpaces.Model.DeleteConnectionAliasResponse, RemoveWKSConnectionAliasCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
