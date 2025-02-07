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
using Amazon.Greengrass;
using Amazon.Greengrass.Model;

namespace Amazon.PowerShell.Cmdlets.GG
{
    /// <summary>
    /// Creates a version of a Lambda function definition that has already been defined.
    /// </summary>
    [Cmdlet("New", "GGFunctionDefinitionVersion", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Greengrass.Model.CreateFunctionDefinitionVersionResponse")]
    [AWSCmdlet("Calls the AWS Greengrass CreateFunctionDefinitionVersion API operation.", Operation = new[] {"CreateFunctionDefinitionVersion"}, SelectReturnType = typeof(Amazon.Greengrass.Model.CreateFunctionDefinitionVersionResponse))]
    [AWSCmdletOutput("Amazon.Greengrass.Model.CreateFunctionDefinitionVersionResponse",
        "This cmdlet returns an Amazon.Greengrass.Model.CreateFunctionDefinitionVersionResponse object containing multiple properties."
    )]
    public partial class NewGGFunctionDefinitionVersionCmdlet : AmazonGreengrassClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AmznClientToken
        /// <summary>
        /// <para>
        /// A client token used to correlate requests
        /// and responses.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AmznClientToken { get; set; }
        #endregion
        
        #region Parameter FunctionDefinitionId
        /// <summary>
        /// <para>
        /// The ID of the Lambda function definition.
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
        public System.String FunctionDefinitionId { get; set; }
        #endregion
        
        #region Parameter Function
        /// <summary>
        /// <para>
        /// A list of Lambda functions in this function
        /// definition version.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Functions")]
        public Amazon.Greengrass.Model.Function[] Function { get; set; }
        #endregion
        
        #region Parameter RunAs_Gid
        /// <summary>
        /// <para>
        /// The group ID whose permissions are used to run a Lambda
        /// function.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultConfig_Execution_RunAs_Gid")]
        public System.Int32? RunAs_Gid { get; set; }
        #endregion
        
        #region Parameter Execution_IsolationMode
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultConfig_Execution_IsolationMode")]
        [AWSConstantClassSource("Amazon.Greengrass.FunctionIsolationMode")]
        public Amazon.Greengrass.FunctionIsolationMode Execution_IsolationMode { get; set; }
        #endregion
        
        #region Parameter RunAs_Uid
        /// <summary>
        /// <para>
        /// The user ID whose permissions are used to run a Lambda
        /// function.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultConfig_Execution_RunAs_Uid")]
        public System.Int32? RunAs_Uid { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Greengrass.Model.CreateFunctionDefinitionVersionResponse).
        /// Specifying the name of a property of type Amazon.Greengrass.Model.CreateFunctionDefinitionVersionResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FunctionDefinitionId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GGFunctionDefinitionVersion (CreateFunctionDefinitionVersion)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Greengrass.Model.CreateFunctionDefinitionVersionResponse, NewGGFunctionDefinitionVersionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AmznClientToken = this.AmznClientToken;
            context.Execution_IsolationMode = this.Execution_IsolationMode;
            context.RunAs_Gid = this.RunAs_Gid;
            context.RunAs_Uid = this.RunAs_Uid;
            context.FunctionDefinitionId = this.FunctionDefinitionId;
            #if MODULAR
            if (this.FunctionDefinitionId == null && ParameterWasBound(nameof(this.FunctionDefinitionId)))
            {
                WriteWarning("You are passing $null as a value for parameter FunctionDefinitionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Function != null)
            {
                context.Function = new List<Amazon.Greengrass.Model.Function>(this.Function);
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
            var request = new Amazon.Greengrass.Model.CreateFunctionDefinitionVersionRequest();
            
            if (cmdletContext.AmznClientToken != null)
            {
                request.AmznClientToken = cmdletContext.AmznClientToken;
            }
            
             // populate DefaultConfig
            var requestDefaultConfigIsNull = true;
            request.DefaultConfig = new Amazon.Greengrass.Model.FunctionDefaultConfig();
            Amazon.Greengrass.Model.FunctionDefaultExecutionConfig requestDefaultConfig_defaultConfig_Execution = null;
            
             // populate Execution
            var requestDefaultConfig_defaultConfig_ExecutionIsNull = true;
            requestDefaultConfig_defaultConfig_Execution = new Amazon.Greengrass.Model.FunctionDefaultExecutionConfig();
            Amazon.Greengrass.FunctionIsolationMode requestDefaultConfig_defaultConfig_Execution_execution_IsolationMode = null;
            if (cmdletContext.Execution_IsolationMode != null)
            {
                requestDefaultConfig_defaultConfig_Execution_execution_IsolationMode = cmdletContext.Execution_IsolationMode;
            }
            if (requestDefaultConfig_defaultConfig_Execution_execution_IsolationMode != null)
            {
                requestDefaultConfig_defaultConfig_Execution.IsolationMode = requestDefaultConfig_defaultConfig_Execution_execution_IsolationMode;
                requestDefaultConfig_defaultConfig_ExecutionIsNull = false;
            }
            Amazon.Greengrass.Model.FunctionRunAsConfig requestDefaultConfig_defaultConfig_Execution_defaultConfig_Execution_RunAs = null;
            
             // populate RunAs
            var requestDefaultConfig_defaultConfig_Execution_defaultConfig_Execution_RunAsIsNull = true;
            requestDefaultConfig_defaultConfig_Execution_defaultConfig_Execution_RunAs = new Amazon.Greengrass.Model.FunctionRunAsConfig();
            System.Int32? requestDefaultConfig_defaultConfig_Execution_defaultConfig_Execution_RunAs_runAs_Gid = null;
            if (cmdletContext.RunAs_Gid != null)
            {
                requestDefaultConfig_defaultConfig_Execution_defaultConfig_Execution_RunAs_runAs_Gid = cmdletContext.RunAs_Gid.Value;
            }
            if (requestDefaultConfig_defaultConfig_Execution_defaultConfig_Execution_RunAs_runAs_Gid != null)
            {
                requestDefaultConfig_defaultConfig_Execution_defaultConfig_Execution_RunAs.Gid = requestDefaultConfig_defaultConfig_Execution_defaultConfig_Execution_RunAs_runAs_Gid.Value;
                requestDefaultConfig_defaultConfig_Execution_defaultConfig_Execution_RunAsIsNull = false;
            }
            System.Int32? requestDefaultConfig_defaultConfig_Execution_defaultConfig_Execution_RunAs_runAs_Uid = null;
            if (cmdletContext.RunAs_Uid != null)
            {
                requestDefaultConfig_defaultConfig_Execution_defaultConfig_Execution_RunAs_runAs_Uid = cmdletContext.RunAs_Uid.Value;
            }
            if (requestDefaultConfig_defaultConfig_Execution_defaultConfig_Execution_RunAs_runAs_Uid != null)
            {
                requestDefaultConfig_defaultConfig_Execution_defaultConfig_Execution_RunAs.Uid = requestDefaultConfig_defaultConfig_Execution_defaultConfig_Execution_RunAs_runAs_Uid.Value;
                requestDefaultConfig_defaultConfig_Execution_defaultConfig_Execution_RunAsIsNull = false;
            }
             // determine if requestDefaultConfig_defaultConfig_Execution_defaultConfig_Execution_RunAs should be set to null
            if (requestDefaultConfig_defaultConfig_Execution_defaultConfig_Execution_RunAsIsNull)
            {
                requestDefaultConfig_defaultConfig_Execution_defaultConfig_Execution_RunAs = null;
            }
            if (requestDefaultConfig_defaultConfig_Execution_defaultConfig_Execution_RunAs != null)
            {
                requestDefaultConfig_defaultConfig_Execution.RunAs = requestDefaultConfig_defaultConfig_Execution_defaultConfig_Execution_RunAs;
                requestDefaultConfig_defaultConfig_ExecutionIsNull = false;
            }
             // determine if requestDefaultConfig_defaultConfig_Execution should be set to null
            if (requestDefaultConfig_defaultConfig_ExecutionIsNull)
            {
                requestDefaultConfig_defaultConfig_Execution = null;
            }
            if (requestDefaultConfig_defaultConfig_Execution != null)
            {
                request.DefaultConfig.Execution = requestDefaultConfig_defaultConfig_Execution;
                requestDefaultConfigIsNull = false;
            }
             // determine if request.DefaultConfig should be set to null
            if (requestDefaultConfigIsNull)
            {
                request.DefaultConfig = null;
            }
            if (cmdletContext.FunctionDefinitionId != null)
            {
                request.FunctionDefinitionId = cmdletContext.FunctionDefinitionId;
            }
            if (cmdletContext.Function != null)
            {
                request.Functions = cmdletContext.Function;
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
        
        private Amazon.Greengrass.Model.CreateFunctionDefinitionVersionResponse CallAWSServiceOperation(IAmazonGreengrass client, Amazon.Greengrass.Model.CreateFunctionDefinitionVersionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Greengrass", "CreateFunctionDefinitionVersion");
            try
            {
                #if DESKTOP
                return client.CreateFunctionDefinitionVersion(request);
                #elif CORECLR
                return client.CreateFunctionDefinitionVersionAsync(request).GetAwaiter().GetResult();
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
            public System.String AmznClientToken { get; set; }
            public Amazon.Greengrass.FunctionIsolationMode Execution_IsolationMode { get; set; }
            public System.Int32? RunAs_Gid { get; set; }
            public System.Int32? RunAs_Uid { get; set; }
            public System.String FunctionDefinitionId { get; set; }
            public List<Amazon.Greengrass.Model.Function> Function { get; set; }
            public System.Func<Amazon.Greengrass.Model.CreateFunctionDefinitionVersionResponse, NewGGFunctionDefinitionVersionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
