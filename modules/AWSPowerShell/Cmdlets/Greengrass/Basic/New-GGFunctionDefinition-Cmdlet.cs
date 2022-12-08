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
    [AWSCmdlet("Calls the AWS Greengrass CreateFunctionDefinition API operation.", Operation = new[] {"CreateFunctionDefinition"}, SelectReturnType = typeof(Amazon.Greengrass.Model.CreateFunctionDefinitionResponse))]
    [AWSCmdletOutput("Amazon.Greengrass.Model.CreateFunctionDefinitionResponse",
        "This cmdlet returns an Amazon.Greengrass.Model.CreateFunctionDefinitionResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AmznClientToken { get; set; }
        #endregion
        
        #region Parameter InitialVersion_Function
        /// <summary>
        /// <para>
        /// A list of Lambda functions in this function
        /// definition version.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InitialVersion_DefaultConfig_Execution_RunAs_Gid")]
        public System.Int32? RunAs_Gid { get; set; }
        #endregion
        
        #region Parameter Execution_IsolationMode
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// Tag(s) to add to the new resource.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter RunAs_Uid
        /// <summary>
        /// <para>
        /// The user ID whose permissions are used to run a Lambda
        /// function.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InitialVersion_DefaultConfig_Execution_RunAs_Uid")]
        public System.Int32? RunAs_Uid { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Greengrass.Model.CreateFunctionDefinitionResponse).
        /// Specifying the name of a property of type Amazon.Greengrass.Model.CreateFunctionDefinitionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GGFunctionDefinition (CreateFunctionDefinition)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Greengrass.Model.CreateFunctionDefinitionResponse, NewGGFunctionDefinitionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AmznClientToken = this.AmznClientToken;
            context.Execution_IsolationMode = this.Execution_IsolationMode;
            context.RunAs_Gid = this.RunAs_Gid;
            context.RunAs_Uid = this.RunAs_Uid;
            if (this.InitialVersion_Function != null)
            {
                context.InitialVersion_Function = new List<Amazon.Greengrass.Model.Function>(this.InitialVersion_Function);
            }
            context.Name = this.Name;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (String)(this.Tag[hashKey]));
                }
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
            var request = new Amazon.Greengrass.Model.CreateFunctionDefinitionRequest();
            
            if (cmdletContext.AmznClientToken != null)
            {
                request.AmznClientToken = cmdletContext.AmznClientToken;
            }
            
             // populate InitialVersion
            var requestInitialVersionIsNull = true;
            request.InitialVersion = new Amazon.Greengrass.Model.FunctionDefinitionVersion();
            List<Amazon.Greengrass.Model.Function> requestInitialVersion_initialVersion_Function = null;
            if (cmdletContext.InitialVersion_Function != null)
            {
                requestInitialVersion_initialVersion_Function = cmdletContext.InitialVersion_Function;
            }
            if (requestInitialVersion_initialVersion_Function != null)
            {
                request.InitialVersion.Functions = requestInitialVersion_initialVersion_Function;
                requestInitialVersionIsNull = false;
            }
            Amazon.Greengrass.Model.FunctionDefaultConfig requestInitialVersion_initialVersion_DefaultConfig = null;
            
             // populate DefaultConfig
            var requestInitialVersion_initialVersion_DefaultConfigIsNull = true;
            requestInitialVersion_initialVersion_DefaultConfig = new Amazon.Greengrass.Model.FunctionDefaultConfig();
            Amazon.Greengrass.Model.FunctionDefaultExecutionConfig requestInitialVersion_initialVersion_DefaultConfig_initialVersion_DefaultConfig_Execution = null;
            
             // populate Execution
            var requestInitialVersion_initialVersion_DefaultConfig_initialVersion_DefaultConfig_ExecutionIsNull = true;
            requestInitialVersion_initialVersion_DefaultConfig_initialVersion_DefaultConfig_Execution = new Amazon.Greengrass.Model.FunctionDefaultExecutionConfig();
            Amazon.Greengrass.FunctionIsolationMode requestInitialVersion_initialVersion_DefaultConfig_initialVersion_DefaultConfig_Execution_execution_IsolationMode = null;
            if (cmdletContext.Execution_IsolationMode != null)
            {
                requestInitialVersion_initialVersion_DefaultConfig_initialVersion_DefaultConfig_Execution_execution_IsolationMode = cmdletContext.Execution_IsolationMode;
            }
            if (requestInitialVersion_initialVersion_DefaultConfig_initialVersion_DefaultConfig_Execution_execution_IsolationMode != null)
            {
                requestInitialVersion_initialVersion_DefaultConfig_initialVersion_DefaultConfig_Execution.IsolationMode = requestInitialVersion_initialVersion_DefaultConfig_initialVersion_DefaultConfig_Execution_execution_IsolationMode;
                requestInitialVersion_initialVersion_DefaultConfig_initialVersion_DefaultConfig_ExecutionIsNull = false;
            }
            Amazon.Greengrass.Model.FunctionRunAsConfig requestInitialVersion_initialVersion_DefaultConfig_initialVersion_DefaultConfig_Execution_initialVersion_DefaultConfig_Execution_RunAs = null;
            
             // populate RunAs
            var requestInitialVersion_initialVersion_DefaultConfig_initialVersion_DefaultConfig_Execution_initialVersion_DefaultConfig_Execution_RunAsIsNull = true;
            requestInitialVersion_initialVersion_DefaultConfig_initialVersion_DefaultConfig_Execution_initialVersion_DefaultConfig_Execution_RunAs = new Amazon.Greengrass.Model.FunctionRunAsConfig();
            System.Int32? requestInitialVersion_initialVersion_DefaultConfig_initialVersion_DefaultConfig_Execution_initialVersion_DefaultConfig_Execution_RunAs_runAs_Gid = null;
            if (cmdletContext.RunAs_Gid != null)
            {
                requestInitialVersion_initialVersion_DefaultConfig_initialVersion_DefaultConfig_Execution_initialVersion_DefaultConfig_Execution_RunAs_runAs_Gid = cmdletContext.RunAs_Gid.Value;
            }
            if (requestInitialVersion_initialVersion_DefaultConfig_initialVersion_DefaultConfig_Execution_initialVersion_DefaultConfig_Execution_RunAs_runAs_Gid != null)
            {
                requestInitialVersion_initialVersion_DefaultConfig_initialVersion_DefaultConfig_Execution_initialVersion_DefaultConfig_Execution_RunAs.Gid = requestInitialVersion_initialVersion_DefaultConfig_initialVersion_DefaultConfig_Execution_initialVersion_DefaultConfig_Execution_RunAs_runAs_Gid.Value;
                requestInitialVersion_initialVersion_DefaultConfig_initialVersion_DefaultConfig_Execution_initialVersion_DefaultConfig_Execution_RunAsIsNull = false;
            }
            System.Int32? requestInitialVersion_initialVersion_DefaultConfig_initialVersion_DefaultConfig_Execution_initialVersion_DefaultConfig_Execution_RunAs_runAs_Uid = null;
            if (cmdletContext.RunAs_Uid != null)
            {
                requestInitialVersion_initialVersion_DefaultConfig_initialVersion_DefaultConfig_Execution_initialVersion_DefaultConfig_Execution_RunAs_runAs_Uid = cmdletContext.RunAs_Uid.Value;
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
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
            public Amazon.Greengrass.FunctionIsolationMode Execution_IsolationMode { get; set; }
            public System.Int32? RunAs_Gid { get; set; }
            public System.Int32? RunAs_Uid { get; set; }
            public List<Amazon.Greengrass.Model.Function> InitialVersion_Function { get; set; }
            public System.String Name { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.Greengrass.Model.CreateFunctionDefinitionResponse, NewGGFunctionDefinitionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
