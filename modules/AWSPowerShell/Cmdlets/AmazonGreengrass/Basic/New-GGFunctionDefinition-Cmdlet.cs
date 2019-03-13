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
    /// Creates a Lambda function definition which contains a list of Lambda functions and
    /// their configurations to be used in a group. You can create an initial version of the
    /// definition by providing a list of Lambda functions and their configurations now, or
    /// use ''CreateFunctionDefinitionVersion'' later.
    /// </summary>
    [Cmdlet("New", "GGFunctionDefinition", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Greengrass.Model.CreateFunctionDefinitionResponse")]
    [AWSCmdlet("Calls the AWS Greengrass CreateFunctionDefinition API operation.", Operation = new[] {"CreateFunctionDefinition"})]
    [AWSCmdletOutput("Amazon.Greengrass.Model.CreateFunctionDefinitionResponse",
        "This cmdlet returns a Amazon.Greengrass.Model.CreateFunctionDefinitionResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewGGFunctionDefinitionCmdlet : AmazonGreengrassClientCmdlet, IExecutor
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
        
        #region Parameter InitialVersion_Function
        /// <summary>
        /// <para>
        /// A list of Lambda functions in this function
        /// definition version.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("InitialVersion_Functions")]
        public Amazon.Greengrass.Model.Function[] InitialVersion_Function { get; set; }
        #endregion
        
        #region Parameter RunAs_Gid
        /// <summary>
        /// <para>
        /// The group ID whose permissions are used to run a Lambda
        /// function.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("InitialVersion_DefaultConfig_Execution_RunAs_Gid")]
        public System.Int32 RunAs_Gid { get; set; }
        #endregion
        
        #region Parameter Execution_IsolationMode
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("InitialVersion_DefaultConfig_Execution_IsolationMode")]
        [AWSConstantClassSource("Amazon.Greengrass.FunctionIsolationMode")]
        public Amazon.Greengrass.FunctionIsolationMode Execution_IsolationMode { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// The name of the function definition.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter RunAs_Uid
        /// <summary>
        /// <para>
        /// The user ID whose permissions are used to run a Lambda
        /// function.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("InitialVersion_DefaultConfig_Execution_RunAs_Uid")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Name", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GGFunctionDefinition (CreateFunctionDefinition)"))
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
            context.InitialVersion_DefaultConfig_Execution_IsolationMode = this.Execution_IsolationMode;
            if (ParameterWasBound("RunAs_Gid"))
                context.InitialVersion_DefaultConfig_Execution_RunAs_Gid = this.RunAs_Gid;
            if (ParameterWasBound("RunAs_Uid"))
                context.InitialVersion_DefaultConfig_Execution_RunAs_Uid = this.RunAs_Uid;
            if (this.InitialVersion_Function != null)
            {
                context.InitialVersion_Functions = new List<Amazon.Greengrass.Model.Function>(this.InitialVersion_Function);
            }
            context.Name = this.Name;
            
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
            var request = new Amazon.Greengrass.Model.CreateFunctionDefinitionRequest();
            
            if (cmdletContext.AmznClientToken != null)
            {
                request.AmznClientToken = cmdletContext.AmznClientToken;
            }
            
             // populate InitialVersion
            bool requestInitialVersionIsNull = true;
            request.InitialVersion = new Amazon.Greengrass.Model.FunctionDefinitionVersion();
            List<Amazon.Greengrass.Model.Function> requestInitialVersion_initialVersion_Function = null;
            if (cmdletContext.InitialVersion_Functions != null)
            {
                requestInitialVersion_initialVersion_Function = cmdletContext.InitialVersion_Functions;
            }
            if (requestInitialVersion_initialVersion_Function != null)
            {
                request.InitialVersion.Functions = requestInitialVersion_initialVersion_Function;
                requestInitialVersionIsNull = false;
            }
            Amazon.Greengrass.Model.FunctionDefaultConfig requestInitialVersion_initialVersion_DefaultConfig = null;
            
             // populate DefaultConfig
            bool requestInitialVersion_initialVersion_DefaultConfigIsNull = true;
            requestInitialVersion_initialVersion_DefaultConfig = new Amazon.Greengrass.Model.FunctionDefaultConfig();
            Amazon.Greengrass.Model.FunctionDefaultExecutionConfig requestInitialVersion_initialVersion_DefaultConfig_initialVersion_DefaultConfig_Execution = null;
            
             // populate Execution
            bool requestInitialVersion_initialVersion_DefaultConfig_initialVersion_DefaultConfig_ExecutionIsNull = true;
            requestInitialVersion_initialVersion_DefaultConfig_initialVersion_DefaultConfig_Execution = new Amazon.Greengrass.Model.FunctionDefaultExecutionConfig();
            Amazon.Greengrass.FunctionIsolationMode requestInitialVersion_initialVersion_DefaultConfig_initialVersion_DefaultConfig_Execution_execution_IsolationMode = null;
            if (cmdletContext.InitialVersion_DefaultConfig_Execution_IsolationMode != null)
            {
                requestInitialVersion_initialVersion_DefaultConfig_initialVersion_DefaultConfig_Execution_execution_IsolationMode = cmdletContext.InitialVersion_DefaultConfig_Execution_IsolationMode;
            }
            if (requestInitialVersion_initialVersion_DefaultConfig_initialVersion_DefaultConfig_Execution_execution_IsolationMode != null)
            {
                requestInitialVersion_initialVersion_DefaultConfig_initialVersion_DefaultConfig_Execution.IsolationMode = requestInitialVersion_initialVersion_DefaultConfig_initialVersion_DefaultConfig_Execution_execution_IsolationMode;
                requestInitialVersion_initialVersion_DefaultConfig_initialVersion_DefaultConfig_ExecutionIsNull = false;
            }
            Amazon.Greengrass.Model.FunctionRunAsConfig requestInitialVersion_initialVersion_DefaultConfig_initialVersion_DefaultConfig_Execution_initialVersion_DefaultConfig_Execution_RunAs = null;
            
             // populate RunAs
            bool requestInitialVersion_initialVersion_DefaultConfig_initialVersion_DefaultConfig_Execution_initialVersion_DefaultConfig_Execution_RunAsIsNull = true;
            requestInitialVersion_initialVersion_DefaultConfig_initialVersion_DefaultConfig_Execution_initialVersion_DefaultConfig_Execution_RunAs = new Amazon.Greengrass.Model.FunctionRunAsConfig();
            System.Int32? requestInitialVersion_initialVersion_DefaultConfig_initialVersion_DefaultConfig_Execution_initialVersion_DefaultConfig_Execution_RunAs_runAs_Gid = null;
            if (cmdletContext.InitialVersion_DefaultConfig_Execution_RunAs_Gid != null)
            {
                requestInitialVersion_initialVersion_DefaultConfig_initialVersion_DefaultConfig_Execution_initialVersion_DefaultConfig_Execution_RunAs_runAs_Gid = cmdletContext.InitialVersion_DefaultConfig_Execution_RunAs_Gid.Value;
            }
            if (requestInitialVersion_initialVersion_DefaultConfig_initialVersion_DefaultConfig_Execution_initialVersion_DefaultConfig_Execution_RunAs_runAs_Gid != null)
            {
                requestInitialVersion_initialVersion_DefaultConfig_initialVersion_DefaultConfig_Execution_initialVersion_DefaultConfig_Execution_RunAs.Gid = requestInitialVersion_initialVersion_DefaultConfig_initialVersion_DefaultConfig_Execution_initialVersion_DefaultConfig_Execution_RunAs_runAs_Gid.Value;
                requestInitialVersion_initialVersion_DefaultConfig_initialVersion_DefaultConfig_Execution_initialVersion_DefaultConfig_Execution_RunAsIsNull = false;
            }
            System.Int32? requestInitialVersion_initialVersion_DefaultConfig_initialVersion_DefaultConfig_Execution_initialVersion_DefaultConfig_Execution_RunAs_runAs_Uid = null;
            if (cmdletContext.InitialVersion_DefaultConfig_Execution_RunAs_Uid != null)
            {
                requestInitialVersion_initialVersion_DefaultConfig_initialVersion_DefaultConfig_Execution_initialVersion_DefaultConfig_Execution_RunAs_runAs_Uid = cmdletContext.InitialVersion_DefaultConfig_Execution_RunAs_Uid.Value;
            }
            if (requestInitialVersion_initialVersion_DefaultConfig_initialVersion_DefaultConfig_Execution_initialVersion_DefaultConfig_Execution_RunAs_runAs_Uid != null)
            {
                requestInitialVersion_initialVersion_DefaultConfig_initialVersion_DefaultConfig_Execution_initialVersion_DefaultConfig_Execution_RunAs.Uid = requestInitialVersion_initialVersion_DefaultConfig_initialVersion_DefaultConfig_Execution_initialVersion_DefaultConfig_Execution_RunAs_runAs_Uid.Value;
                requestInitialVersion_initialVersion_DefaultConfig_initialVersion_DefaultConfig_Execution_initialVersion_DefaultConfig_Execution_RunAsIsNull = false;
            }
             // determine if requestInitialVersion_initialVersion_DefaultConfig_initialVersion_DefaultConfig_Execution_initialVersion_DefaultConfig_Execution_RunAs should be set to null
            if (requestInitialVersion_initialVersion_DefaultConfig_initialVersion_DefaultConfig_Execution_initialVersion_DefaultConfig_Execution_RunAsIsNull)
            {
                requestInitialVersion_initialVersion_DefaultConfig_initialVersion_DefaultConfig_Execution_initialVersion_DefaultConfig_Execution_RunAs = null;
            }
            if (requestInitialVersion_initialVersion_DefaultConfig_initialVersion_DefaultConfig_Execution_initialVersion_DefaultConfig_Execution_RunAs != null)
            {
                requestInitialVersion_initialVersion_DefaultConfig_initialVersion_DefaultConfig_Execution.RunAs = requestInitialVersion_initialVersion_DefaultConfig_initialVersion_DefaultConfig_Execution_initialVersion_DefaultConfig_Execution_RunAs;
                requestInitialVersion_initialVersion_DefaultConfig_initialVersion_DefaultConfig_ExecutionIsNull = false;
            }
             // determine if requestInitialVersion_initialVersion_DefaultConfig_initialVersion_DefaultConfig_Execution should be set to null
            if (requestInitialVersion_initialVersion_DefaultConfig_initialVersion_DefaultConfig_ExecutionIsNull)
            {
                requestInitialVersion_initialVersion_DefaultConfig_initialVersion_DefaultConfig_Execution = null;
            }
            if (requestInitialVersion_initialVersion_DefaultConfig_initialVersion_DefaultConfig_Execution != null)
            {
                requestInitialVersion_initialVersion_DefaultConfig.Execution = requestInitialVersion_initialVersion_DefaultConfig_initialVersion_DefaultConfig_Execution;
                requestInitialVersion_initialVersion_DefaultConfigIsNull = false;
            }
             // determine if requestInitialVersion_initialVersion_DefaultConfig should be set to null
            if (requestInitialVersion_initialVersion_DefaultConfigIsNull)
            {
                requestInitialVersion_initialVersion_DefaultConfig = null;
            }
            if (requestInitialVersion_initialVersion_DefaultConfig != null)
            {
                request.InitialVersion.DefaultConfig = requestInitialVersion_initialVersion_DefaultConfig;
                requestInitialVersionIsNull = false;
            }
             // determine if request.InitialVersion should be set to null
            if (requestInitialVersionIsNull)
            {
                request.InitialVersion = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
        
        private Amazon.Greengrass.Model.CreateFunctionDefinitionResponse CallAWSServiceOperation(IAmazonGreengrass client, Amazon.Greengrass.Model.CreateFunctionDefinitionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Greengrass", "CreateFunctionDefinition");
            try
            {
                #if DESKTOP
                return client.CreateFunctionDefinition(request);
                #elif CORECLR
                return client.CreateFunctionDefinitionAsync(request).GetAwaiter().GetResult();
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
            public Amazon.Greengrass.FunctionIsolationMode InitialVersion_DefaultConfig_Execution_IsolationMode { get; set; }
            public System.Int32? InitialVersion_DefaultConfig_Execution_RunAs_Gid { get; set; }
            public System.Int32? InitialVersion_DefaultConfig_Execution_RunAs_Uid { get; set; }
            public List<Amazon.Greengrass.Model.Function> InitialVersion_Functions { get; set; }
            public System.String Name { get; set; }
        }
        
    }
}
