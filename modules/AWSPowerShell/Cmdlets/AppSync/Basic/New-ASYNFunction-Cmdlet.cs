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
using Amazon.AppSync;
using Amazon.AppSync.Model;

namespace Amazon.PowerShell.Cmdlets.ASYN
{
    /// <summary>
    /// Creates a <c>Function</c> object.
    /// 
    ///  
    /// <para>
    /// A function is a reusable entity. You can use multiple functions to compose the resolver
    /// logic.
    /// </para>
    /// </summary>
    [Cmdlet("New", "ASYNFunction", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AppSync.Model.FunctionConfiguration")]
    [AWSCmdlet("Calls the AWS AppSync CreateFunction API operation.", Operation = new[] {"CreateFunction"}, SelectReturnType = typeof(Amazon.AppSync.Model.CreateFunctionResponse))]
    [AWSCmdletOutput("Amazon.AppSync.Model.FunctionConfiguration or Amazon.AppSync.Model.CreateFunctionResponse",
        "This cmdlet returns an Amazon.AppSync.Model.FunctionConfiguration object.",
        "The service call response (type Amazon.AppSync.Model.CreateFunctionResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewASYNFunctionCmdlet : AmazonAppSyncClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ApiId
        /// <summary>
        /// <para>
        /// <para>The GraphQL API ID.</para>
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
        public System.String ApiId { get; set; }
        #endregion
        
        #region Parameter Code
        /// <summary>
        /// <para>
        /// <para>The <c>function</c> code that contains the request and response functions. When code
        /// is used, the <c>runtime</c> is required. The <c>runtime</c> value must be <c>APPSYNC_JS</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Code { get; set; }
        #endregion
        
        #region Parameter SyncConfig_ConflictDetection
        /// <summary>
        /// <para>
        /// <para>The Conflict Detection strategy to use.</para><ul><li><para><b>VERSION</b>: Detect conflicts based on object versions for this resolver.</para></li><li><para><b>NONE</b>: Do not detect conflicts when invoking this resolver.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.AppSync.ConflictDetectionType")]
        public Amazon.AppSync.ConflictDetectionType SyncConfig_ConflictDetection { get; set; }
        #endregion
        
        #region Parameter SyncConfig_ConflictHandler
        /// <summary>
        /// <para>
        /// <para>The Conflict Resolution strategy to perform in the event of a conflict.</para><ul><li><para><b>OPTIMISTIC_CONCURRENCY</b>: Resolve conflicts by rejecting mutations when versions
        /// don't match the latest version at the server.</para></li><li><para><b>AUTOMERGE</b>: Resolve conflicts with the Automerge conflict resolution strategy.</para></li><li><para><b>LAMBDA</b>: Resolve conflicts with an Lambda function supplied in the <c>LambdaConflictHandlerConfig</c>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.AppSync.ConflictHandlerType")]
        public Amazon.AppSync.ConflictHandlerType SyncConfig_ConflictHandler { get; set; }
        #endregion
        
        #region Parameter DataSourceName
        /// <summary>
        /// <para>
        /// <para>The <c>Function</c><c>DataSource</c> name.</para>
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
        public System.String DataSourceName { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The <c>Function</c> description.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter FunctionVersion
        /// <summary>
        /// <para>
        /// <para>The <c>version</c> of the request mapping template. Currently, the supported value
        /// is 2018-05-29. Note that when using VTL and mapping templates, the <c>functionVersion</c>
        /// is required.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FunctionVersion { get; set; }
        #endregion
        
        #region Parameter LambdaConflictHandlerConfig_LambdaConflictHandlerArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) for the Lambda function to use as the Conflict Handler.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SyncConfig_LambdaConflictHandlerConfig_LambdaConflictHandlerArn")]
        public System.String LambdaConflictHandlerConfig_LambdaConflictHandlerArn { get; set; }
        #endregion
        
        #region Parameter MaxBatchSize
        /// <summary>
        /// <para>
        /// <para>The maximum batching size for a resolver.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MaxBatchSize { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The <c>Function</c> name. The function name does not have to be unique.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Runtime_Name
        /// <summary>
        /// <para>
        /// <para>The <c>name</c> of the runtime to use. Currently, the only allowed value is <c>APPSYNC_JS</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.AppSync.RuntimeName")]
        public Amazon.AppSync.RuntimeName Runtime_Name { get; set; }
        #endregion
        
        #region Parameter RequestMappingTemplate
        /// <summary>
        /// <para>
        /// <para>The <c>Function</c> request mapping template. Functions support only the 2018-05-29
        /// version of the request mapping template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RequestMappingTemplate { get; set; }
        #endregion
        
        #region Parameter ResponseMappingTemplate
        /// <summary>
        /// <para>
        /// <para>The <c>Function</c> response mapping template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResponseMappingTemplate { get; set; }
        #endregion
        
        #region Parameter Runtime_RuntimeVersion
        /// <summary>
        /// <para>
        /// <para>The <c>version</c> of the runtime to use. Currently, the only allowed version is <c>1.0.0</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Runtime_RuntimeVersion { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'FunctionConfiguration'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppSync.Model.CreateFunctionResponse).
        /// Specifying the name of a property of type Amazon.AppSync.Model.CreateFunctionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "FunctionConfiguration";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ApiId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ASYNFunction (CreateFunction)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppSync.Model.CreateFunctionResponse, NewASYNFunctionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApiId = this.ApiId;
            #if MODULAR
            if (this.ApiId == null && ParameterWasBound(nameof(this.ApiId)))
            {
                WriteWarning("You are passing $null as a value for parameter ApiId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Code = this.Code;
            context.DataSourceName = this.DataSourceName;
            #if MODULAR
            if (this.DataSourceName == null && ParameterWasBound(nameof(this.DataSourceName)))
            {
                WriteWarning("You are passing $null as a value for parameter DataSourceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            context.FunctionVersion = this.FunctionVersion;
            context.MaxBatchSize = this.MaxBatchSize;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RequestMappingTemplate = this.RequestMappingTemplate;
            context.ResponseMappingTemplate = this.ResponseMappingTemplate;
            context.Runtime_Name = this.Runtime_Name;
            context.Runtime_RuntimeVersion = this.Runtime_RuntimeVersion;
            context.SyncConfig_ConflictDetection = this.SyncConfig_ConflictDetection;
            context.SyncConfig_ConflictHandler = this.SyncConfig_ConflictHandler;
            context.LambdaConflictHandlerConfig_LambdaConflictHandlerArn = this.LambdaConflictHandlerConfig_LambdaConflictHandlerArn;
            
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
            var request = new Amazon.AppSync.Model.CreateFunctionRequest();
            
            if (cmdletContext.ApiId != null)
            {
                request.ApiId = cmdletContext.ApiId;
            }
            if (cmdletContext.Code != null)
            {
                request.Code = cmdletContext.Code;
            }
            if (cmdletContext.DataSourceName != null)
            {
                request.DataSourceName = cmdletContext.DataSourceName;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.FunctionVersion != null)
            {
                request.FunctionVersion = cmdletContext.FunctionVersion;
            }
            if (cmdletContext.MaxBatchSize != null)
            {
                request.MaxBatchSize = cmdletContext.MaxBatchSize.Value;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.RequestMappingTemplate != null)
            {
                request.RequestMappingTemplate = cmdletContext.RequestMappingTemplate;
            }
            if (cmdletContext.ResponseMappingTemplate != null)
            {
                request.ResponseMappingTemplate = cmdletContext.ResponseMappingTemplate;
            }
            
             // populate Runtime
            var requestRuntimeIsNull = true;
            request.Runtime = new Amazon.AppSync.Model.AppSyncRuntime();
            Amazon.AppSync.RuntimeName requestRuntime_runtime_Name = null;
            if (cmdletContext.Runtime_Name != null)
            {
                requestRuntime_runtime_Name = cmdletContext.Runtime_Name;
            }
            if (requestRuntime_runtime_Name != null)
            {
                request.Runtime.Name = requestRuntime_runtime_Name;
                requestRuntimeIsNull = false;
            }
            System.String requestRuntime_runtime_RuntimeVersion = null;
            if (cmdletContext.Runtime_RuntimeVersion != null)
            {
                requestRuntime_runtime_RuntimeVersion = cmdletContext.Runtime_RuntimeVersion;
            }
            if (requestRuntime_runtime_RuntimeVersion != null)
            {
                request.Runtime.RuntimeVersion = requestRuntime_runtime_RuntimeVersion;
                requestRuntimeIsNull = false;
            }
             // determine if request.Runtime should be set to null
            if (requestRuntimeIsNull)
            {
                request.Runtime = null;
            }
            
             // populate SyncConfig
            var requestSyncConfigIsNull = true;
            request.SyncConfig = new Amazon.AppSync.Model.SyncConfig();
            Amazon.AppSync.ConflictDetectionType requestSyncConfig_syncConfig_ConflictDetection = null;
            if (cmdletContext.SyncConfig_ConflictDetection != null)
            {
                requestSyncConfig_syncConfig_ConflictDetection = cmdletContext.SyncConfig_ConflictDetection;
            }
            if (requestSyncConfig_syncConfig_ConflictDetection != null)
            {
                request.SyncConfig.ConflictDetection = requestSyncConfig_syncConfig_ConflictDetection;
                requestSyncConfigIsNull = false;
            }
            Amazon.AppSync.ConflictHandlerType requestSyncConfig_syncConfig_ConflictHandler = null;
            if (cmdletContext.SyncConfig_ConflictHandler != null)
            {
                requestSyncConfig_syncConfig_ConflictHandler = cmdletContext.SyncConfig_ConflictHandler;
            }
            if (requestSyncConfig_syncConfig_ConflictHandler != null)
            {
                request.SyncConfig.ConflictHandler = requestSyncConfig_syncConfig_ConflictHandler;
                requestSyncConfigIsNull = false;
            }
            Amazon.AppSync.Model.LambdaConflictHandlerConfig requestSyncConfig_syncConfig_LambdaConflictHandlerConfig = null;
            
             // populate LambdaConflictHandlerConfig
            var requestSyncConfig_syncConfig_LambdaConflictHandlerConfigIsNull = true;
            requestSyncConfig_syncConfig_LambdaConflictHandlerConfig = new Amazon.AppSync.Model.LambdaConflictHandlerConfig();
            System.String requestSyncConfig_syncConfig_LambdaConflictHandlerConfig_lambdaConflictHandlerConfig_LambdaConflictHandlerArn = null;
            if (cmdletContext.LambdaConflictHandlerConfig_LambdaConflictHandlerArn != null)
            {
                requestSyncConfig_syncConfig_LambdaConflictHandlerConfig_lambdaConflictHandlerConfig_LambdaConflictHandlerArn = cmdletContext.LambdaConflictHandlerConfig_LambdaConflictHandlerArn;
            }
            if (requestSyncConfig_syncConfig_LambdaConflictHandlerConfig_lambdaConflictHandlerConfig_LambdaConflictHandlerArn != null)
            {
                requestSyncConfig_syncConfig_LambdaConflictHandlerConfig.LambdaConflictHandlerArn = requestSyncConfig_syncConfig_LambdaConflictHandlerConfig_lambdaConflictHandlerConfig_LambdaConflictHandlerArn;
                requestSyncConfig_syncConfig_LambdaConflictHandlerConfigIsNull = false;
            }
             // determine if requestSyncConfig_syncConfig_LambdaConflictHandlerConfig should be set to null
            if (requestSyncConfig_syncConfig_LambdaConflictHandlerConfigIsNull)
            {
                requestSyncConfig_syncConfig_LambdaConflictHandlerConfig = null;
            }
            if (requestSyncConfig_syncConfig_LambdaConflictHandlerConfig != null)
            {
                request.SyncConfig.LambdaConflictHandlerConfig = requestSyncConfig_syncConfig_LambdaConflictHandlerConfig;
                requestSyncConfigIsNull = false;
            }
             // determine if request.SyncConfig should be set to null
            if (requestSyncConfigIsNull)
            {
                request.SyncConfig = null;
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
        
        private Amazon.AppSync.Model.CreateFunctionResponse CallAWSServiceOperation(IAmazonAppSync client, Amazon.AppSync.Model.CreateFunctionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS AppSync", "CreateFunction");
            try
            {
                #if DESKTOP
                return client.CreateFunction(request);
                #elif CORECLR
                return client.CreateFunctionAsync(request).GetAwaiter().GetResult();
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
            public System.String ApiId { get; set; }
            public System.String Code { get; set; }
            public System.String DataSourceName { get; set; }
            public System.String Description { get; set; }
            public System.String FunctionVersion { get; set; }
            public System.Int32? MaxBatchSize { get; set; }
            public System.String Name { get; set; }
            public System.String RequestMappingTemplate { get; set; }
            public System.String ResponseMappingTemplate { get; set; }
            public Amazon.AppSync.RuntimeName Runtime_Name { get; set; }
            public System.String Runtime_RuntimeVersion { get; set; }
            public Amazon.AppSync.ConflictDetectionType SyncConfig_ConflictDetection { get; set; }
            public Amazon.AppSync.ConflictHandlerType SyncConfig_ConflictHandler { get; set; }
            public System.String LambdaConflictHandlerConfig_LambdaConflictHandlerArn { get; set; }
            public System.Func<Amazon.AppSync.Model.CreateFunctionResponse, NewASYNFunctionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.FunctionConfiguration;
        }
        
    }
}
