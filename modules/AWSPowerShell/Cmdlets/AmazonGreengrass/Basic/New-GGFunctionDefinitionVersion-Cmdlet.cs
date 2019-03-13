/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    [AWSCmdlet("Calls the AWS Greengrass CreateFunctionDefinitionVersion API operation.", Operation = new[] {"CreateFunctionDefinitionVersion"})]
    [AWSCmdletOutput("Amazon.Greengrass.Model.CreateFunctionDefinitionVersionResponse",
        "This cmdlet returns a Amazon.Greengrass.Model.CreateFunctionDefinitionVersionResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewGGFunctionDefinitionVersionCmdlet : AmazonGreengrassClientCmdlet, IExecutor
    {
        
        #region Parameter AmznClientToken
        /// <summary>
        /// <para>
        /// A client token used to correlate requests
        /// and responses.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AmznClientToken { get; set; }
        #endregion
        
        #region Parameter FunctionDefinitionId
        /// <summary>
        /// <para>
        /// The ID of the Lambda function definition.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String FunctionDefinitionId { get; set; }
        #endregion
        
        #region Parameter Function
        /// <summary>
        /// <para>
        /// A list of Lambda functions in this function
        /// definition version.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
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
        [System.Management.Automation.Parameter]
        [Alias("DefaultConfig_Execution_RunAs_Gid")]
        public System.Int32 RunAs_Gid { get; set; }
        #endregion
        
        #region Parameter Execution_IsolationMode
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
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
        [System.Management.Automation.Parameter]
        [Alias("DefaultConfig_Execution_RunAs_Uid")]
        public System.Int32 RunAs_Uid { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("FunctionDefinitionId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GGFunctionDefinitionVersion (CreateFunctionDefinitionVersion)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.AmznClientToken = this.AmznClientToken;
            context.DefaultConfig_Execution_IsolationMode = this.Execution_IsolationMode;
            if (ParameterWasBound("RunAs_Gid"))
                context.DefaultConfig_Execution_RunAs_Gid = this.RunAs_Gid;
            if (ParameterWasBound("RunAs_Uid"))
                context.DefaultConfig_Execution_RunAs_Uid = this.RunAs_Uid;
            context.FunctionDefinitionId = this.FunctionDefinitionId;
            if (this.Function != null)
            {
                context.Functions = new List<Amazon.Greengrass.Model.Function>(this.Function);
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
            bool requestDefaultConfigIsNull = true;
            request.DefaultConfig = new Amazon.Greengrass.Model.FunctionDefaultConfig();
            Amazon.Greengrass.Model.FunctionDefaultExecutionConfig requestDefaultConfig_defaultConfig_Execution = null;
            
             // populate Execution
            bool requestDefaultConfig_defaultConfig_ExecutionIsNull = true;
            requestDefaultConfig_defaultConfig_Execution = new Amazon.Greengrass.Model.FunctionDefaultExecutionConfig();
            Amazon.Greengrass.FunctionIsolationMode requestDefaultConfig_defaultConfig_Execution_execution_IsolationMode = null;
            if (cmdletContext.DefaultConfig_Execution_IsolationMode != null)
            {
                requestDefaultConfig_defaultConfig_Execution_execution_IsolationMode = cmdletContext.DefaultConfig_Execution_IsolationMode;
            }
            if (requestDefaultConfig_defaultConfig_Execution_execution_IsolationMode != null)
            {
                requestDefaultConfig_defaultConfig_Execution.IsolationMode = requestDefaultConfig_defaultConfig_Execution_execution_IsolationMode;
                requestDefaultConfig_defaultConfig_ExecutionIsNull = false;
            }
            Amazon.Greengrass.Model.FunctionRunAsConfig requestDefaultConfig_defaultConfig_Execution_defaultConfig_Execution_RunAs = null;
            
             // populate RunAs
            bool requestDefaultConfig_defaultConfig_Execution_defaultConfig_Execution_RunAsIsNull = true;
            requestDefaultConfig_defaultConfig_Execution_defaultConfig_Execution_RunAs = new Amazon.Greengrass.Model.FunctionRunAsConfig();
            System.Int32? requestDefaultConfig_defaultConfig_Execution_defaultConfig_Execution_RunAs_runAs_Gid = null;
            if (cmdletContext.DefaultConfig_Execution_RunAs_Gid != null)
            {
                requestDefaultConfig_defaultConfig_Execution_defaultConfig_Execution_RunAs_runAs_Gid = cmdletContext.DefaultConfig_Execution_RunAs_Gid.Value;
            }
            if (requestDefaultConfig_defaultConfig_Execution_defaultConfig_Execution_RunAs_runAs_Gid != null)
            {
                requestDefaultConfig_defaultConfig_Execution_defaultConfig_Execution_RunAs.Gid = requestDefaultConfig_defaultConfig_Execution_defaultConfig_Execution_RunAs_runAs_Gid.Value;
                requestDefaultConfig_defaultConfig_Execution_defaultConfig_Execution_RunAsIsNull = false;
            }
            System.Int32? requestDefaultConfig_defaultConfig_Execution_defaultConfig_Execution_RunAs_runAs_Uid = null;
            if (cmdletContext.DefaultConfig_Execution_RunAs_Uid != null)
            {
                requestDefaultConfig_defaultConfig_Execution_defaultConfig_Execution_RunAs_runAs_Uid = cmdletContext.DefaultConfig_Execution_RunAs_Uid.Value;
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
            if (cmdletContext.Functions != null)
            {
                request.Functions = cmdletContext.Functions;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
            public Amazon.Greengrass.FunctionIsolationMode DefaultConfig_Execution_IsolationMode { get; set; }
            public System.Int32? DefaultConfig_Execution_RunAs_Gid { get; set; }
            public System.Int32? DefaultConfig_Execution_RunAs_Uid { get; set; }
            public System.String FunctionDefinitionId { get; set; }
            public List<Amazon.Greengrass.Model.Function> Functions { get; set; }
        }
        
    }
}
