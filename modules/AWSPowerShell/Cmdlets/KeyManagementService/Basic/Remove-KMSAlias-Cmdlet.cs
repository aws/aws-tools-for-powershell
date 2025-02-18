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
using System.Threading;
using Amazon.KeyManagementService;
using Amazon.KeyManagementService.Model;

namespace Amazon.PowerShell.Cmdlets.KMS
{
    /// <summary>
    /// Deletes the specified alias. 
    /// 
    ///  <note><para>
    /// Adding, deleting, or updating an alias can allow or deny permission to the KMS key.
    /// For details, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/abac.html">ABAC
    /// for KMS</a> in the <i>Key Management Service Developer Guide</i>.
    /// </para></note><para>
    /// Because an alias is not a property of a KMS key, you can delete and change the aliases
    /// of a KMS key without affecting the KMS key. Also, aliases do not appear in the response
    /// from the <a>DescribeKey</a> operation. To get the aliases of all KMS keys, use the
    /// <a>ListAliases</a> operation. 
    /// </para><para>
    /// Each KMS key can have multiple aliases. To change the alias of a KMS key, use <a>DeleteAlias</a>
    /// to delete the current alias and <a>CreateAlias</a> to create a new alias. To associate
    /// an existing alias with a different KMS key, call <a>UpdateAlias</a>.
    /// </para><para><b>Cross-account use</b>: No. You cannot perform this operation on an alias in a
    /// different Amazon Web Services account.
    /// </para><para><b>Required permissions</b></para><ul><li><para><a href="https://docs.aws.amazon.com/kms/latest/developerguide/kms-api-permissions-reference.html">kms:DeleteAlias</a>
    /// on the alias (IAM policy).
    /// </para></li><li><para><a href="https://docs.aws.amazon.com/kms/latest/developerguide/kms-api-permissions-reference.html">kms:DeleteAlias</a>
    /// on the KMS key (key policy).
    /// </para></li></ul><para>
    /// For details, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/kms-alias.html#alias-access">Controlling
    /// access to aliases</a> in the <i>Key Management Service Developer Guide</i>.
    /// </para><para><b>Related operations:</b></para><ul><li><para><a>CreateAlias</a></para></li><li><para><a>ListAliases</a></para></li><li><para><a>UpdateAlias</a></para></li></ul><para><b>Eventual consistency</b>: The KMS API follows an eventual consistency model. For
    /// more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/programming-eventual-consistency.html">KMS
    /// eventual consistency</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "KMSAlias", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Key Management Service DeleteAlias API operation.", Operation = new[] {"DeleteAlias"}, SelectReturnType = typeof(Amazon.KeyManagementService.Model.DeleteAliasResponse))]
    [AWSCmdletOutput("None or Amazon.KeyManagementService.Model.DeleteAliasResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.KeyManagementService.Model.DeleteAliasResponse) be returned by specifying '-Select *'."
    )]
    public partial class RemoveKMSAliasCmdlet : AmazonKeyManagementServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AliasName
        /// <summary>
        /// <para>
        /// <para>The alias to be deleted. The alias name must begin with <c>alias/</c> followed by
        /// the alias name, such as <c>alias/ExampleAlias</c>.</para>
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
        public System.String AliasName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KeyManagementService.Model.DeleteAliasResponse).
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AliasName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-KMSAlias (DeleteAlias)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.KeyManagementService.Model.DeleteAliasResponse, RemoveKMSAliasCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AliasName = this.AliasName;
            #if MODULAR
            if (this.AliasName == null && ParameterWasBound(nameof(this.AliasName)))
            {
                WriteWarning("You are passing $null as a value for parameter AliasName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.KeyManagementService.Model.DeleteAliasRequest();
            
            if (cmdletContext.AliasName != null)
            {
                request.AliasName = cmdletContext.AliasName;
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
        
        private Amazon.KeyManagementService.Model.DeleteAliasResponse CallAWSServiceOperation(IAmazonKeyManagementService client, Amazon.KeyManagementService.Model.DeleteAliasRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Key Management Service", "DeleteAlias");
            try
            {
                return client.DeleteAliasAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AliasName { get; set; }
            public System.Func<Amazon.KeyManagementService.Model.DeleteAliasResponse, RemoveKMSAliasCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
