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
using Amazon.Chime;
using Amazon.Chime.Model;

namespace Amazon.PowerShell.Cmdlets.CHM
{
    /// <summary>
    /// Deletes an <c>AppInstanceUser</c>.
    /// 
    ///  <important><para><b>This API is is no longer supported and will not be updated.</b> We recommend using
    /// the latest version, <a href="https://docs.aws.amazon.com/chime-sdk/latest/APIReference/API_identity-chime_DeleteAppInstanceUser.html">DeleteAppInstanceUser</a>,
    /// in the Amazon Chime SDK.
    /// </para><para>
    /// Using the latest version requires migrating to a dedicated namespace. For more information,
    /// refer to <a href="https://docs.aws.amazon.com/chime-sdk/latest/dg/migrate-from-chm-namespace.html">Migrating
    /// from the Amazon Chime namespace</a> in the <i>Amazon Chime SDK Developer Guide</i>.
    /// </para></important><br/><br/>This operation is deprecated.
    /// </summary>
    [Cmdlet("Remove", "CHMAppInstanceUser", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Chime DeleteAppInstanceUser API operation.", Operation = new[] {"DeleteAppInstanceUser"}, SelectReturnType = typeof(Amazon.Chime.Model.DeleteAppInstanceUserResponse))]
    [AWSCmdletOutput("None or Amazon.Chime.Model.DeleteAppInstanceUserResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Chime.Model.DeleteAppInstanceUserResponse) be returned by specifying '-Select *'."
    )]
    [System.ObsoleteAttribute("Replaced by DeleteAppInstanceUser in the Amazon Chime SDK Identity Namespace")]
    public partial class RemoveCHMAppInstanceUserCmdlet : AmazonChimeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AppInstanceUserArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the user request being deleted.</para>
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
        public System.String AppInstanceUserArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Chime.Model.DeleteAppInstanceUserResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AppInstanceUserArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-CHMAppInstanceUser (DeleteAppInstanceUser)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Chime.Model.DeleteAppInstanceUserResponse, RemoveCHMAppInstanceUserCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AppInstanceUserArn = this.AppInstanceUserArn;
            #if MODULAR
            if (this.AppInstanceUserArn == null && ParameterWasBound(nameof(this.AppInstanceUserArn)))
            {
                WriteWarning("You are passing $null as a value for parameter AppInstanceUserArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Chime.Model.DeleteAppInstanceUserRequest();
            
            if (cmdletContext.AppInstanceUserArn != null)
            {
                request.AppInstanceUserArn = cmdletContext.AppInstanceUserArn;
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
        
        private Amazon.Chime.Model.DeleteAppInstanceUserResponse CallAWSServiceOperation(IAmazonChime client, Amazon.Chime.Model.DeleteAppInstanceUserRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Chime", "DeleteAppInstanceUser");
            try
            {
                return client.DeleteAppInstanceUserAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AppInstanceUserArn { get; set; }
            public System.Func<Amazon.Chime.Model.DeleteAppInstanceUserResponse, RemoveCHMAppInstanceUserCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
