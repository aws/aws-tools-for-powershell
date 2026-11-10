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
using Amazon.LakeFormation;
using Amazon.LakeFormation.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.LKF
{
    /// <summary>
    /// Returns a session context for one or more user-defined functions that an integrated
    /// analytics engine runs together in a job. You must have the <c>EXECUTE</c> permission
    /// on every function in the list.
    /// 
    ///  
    /// <para>
    /// While the session context is in use, if you don't have full <c>SELECT</c> permission
    /// on a table, the job can read the table only if every function in the session has the
    /// <c>SELECT</c> permission on it. Lake Formation enforces this check.
    /// </para><para>
    /// To use this operation, you must have the <c>lakeformation:GetDataAccess</c> permission.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "LKFGlueFunctionSessionContext")]
    [OutputType("Amazon.LakeFormation.Model.GetGlueFunctionSessionContextResponse")]
    [AWSCmdlet("Calls the AWS Lake Formation GetGlueFunctionSessionContext API operation.", Operation = new[] {"GetGlueFunctionSessionContext"}, SelectReturnType = typeof(Amazon.LakeFormation.Model.GetGlueFunctionSessionContextResponse))]
    [AWSCmdletOutput("Amazon.LakeFormation.Model.GetGlueFunctionSessionContextResponse",
        "This cmdlet returns an Amazon.LakeFormation.Model.GetGlueFunctionSessionContextResponse object containing multiple properties."
    )]
    public partial class GetLKFGlueFunctionSessionContextCmdlet : AmazonLakeFormationClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DurationSecond
        /// <summary>
        /// <para>
        /// <para>The number of seconds the session context is valid. The default is 86,400 (24 hours).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("DurationSeconds")]
        public System.Int32? DurationSecond { get; set; }
        #endregion
        
        #region Parameter UserDefinedFunctionArn
        /// <summary>
        /// <para>
        /// <para>The ARNs of one or more user-defined functions to include in the session context,
        /// each in the format <c>arn:aws:glue:<i>region</i>:<i>account-id</i>:userDefinedFunction/<i>database-name</i>/<i>function-name</i></c>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        [Alias("UserDefinedFunctionArns")]
        public System.String[] UserDefinedFunctionArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LakeFormation.Model.GetGlueFunctionSessionContextResponse).
        /// Specifying the name of a property of type Amazon.LakeFormation.Model.GetGlueFunctionSessionContextResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LakeFormation.Model.GetGlueFunctionSessionContextResponse, GetLKFGlueFunctionSessionContextCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DurationSecond = this.DurationSecond;
            if (this.UserDefinedFunctionArn != null)
            {
                context.UserDefinedFunctionArn = new List<System.String>(this.UserDefinedFunctionArn);
            }
            #if MODULAR
            if (this.UserDefinedFunctionArn == null && ParameterWasBound(nameof(this.UserDefinedFunctionArn)))
            {
                WriteWarning("You are passing $null as a value for parameter UserDefinedFunctionArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.LakeFormation.Model.GetGlueFunctionSessionContextRequest();
            
            if (cmdletContext.DurationSecond != null)
            {
                request.DurationSeconds = cmdletContext.DurationSecond.Value;
            }
            if (cmdletContext.UserDefinedFunctionArn != null)
            {
                request.UserDefinedFunctionArns = cmdletContext.UserDefinedFunctionArn;
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
        
        private Amazon.LakeFormation.Model.GetGlueFunctionSessionContextResponse CallAWSServiceOperation(IAmazonLakeFormation client, Amazon.LakeFormation.Model.GetGlueFunctionSessionContextRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Lake Formation", "GetGlueFunctionSessionContext");
            try
            {
                return client.GetGlueFunctionSessionContextAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? DurationSecond { get; set; }
            public List<System.String> UserDefinedFunctionArn { get; set; }
            public System.Func<Amazon.LakeFormation.Model.GetGlueFunctionSessionContextResponse, GetLKFGlueFunctionSessionContextCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
