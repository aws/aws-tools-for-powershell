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
    /// Creates a <code>Resolver</code> object.
    /// 
    ///  
    /// <para>
    /// A resolver converts incoming requests into a format that a data source can understand
    /// and converts the data source's responses into GraphQL.
    /// </para>
    /// </summary>
    [Cmdlet("New", "ASYNResolver", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AppSync.Model.Resolver")]
    [AWSCmdlet("Calls the AWS AppSync CreateResolver API operation.", Operation = new[] {"CreateResolver"}, SelectReturnType = typeof(Amazon.AppSync.Model.CreateResolverResponse))]
    [AWSCmdletOutput("Amazon.AppSync.Model.Resolver or Amazon.AppSync.Model.CreateResolverResponse",
        "This cmdlet returns an Amazon.AppSync.Model.Resolver object.",
        "The service call response (type Amazon.AppSync.Model.CreateResolverResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewASYNResolverCmdlet : AmazonAppSyncClientCmdlet, IExecutor
    {
        
        #region Parameter ApiId
        /// <summary>
        /// <para>
        /// <para>The ID for the GraphQL API for which the resolver is being created.</para>
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
        public System.String ApiId { get; set; }
        #endregion
        
        #region Parameter CachingConfig_CachingKey
        /// <summary>
        /// <para>
        /// <para>The caching keys for a resolver that has caching enabled.</para><para>Valid values are entries from the <code>$context.arguments</code>, <code>$context.source</code>,
        /// and <code>$context.identity</code> maps.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CachingConfig_CachingKeys")]
        public System.String[] CachingConfig_CachingKey { get; set; }
        #endregion
        
        #region Parameter SyncConfig_ConflictDetection
        /// <summary>
        /// <para>
        /// <para>The Conflict Detection strategy to use.</para><ul><li><para><b>VERSION</b>: Detect conflicts based on object versions for this resolver.</para></li><li><para><b>NONE</b>: Do not detect conflicts when executing this resolver.</para></li></ul>
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
        /// do not match the latest version at the server.</para></li><li><para><b>AUTOMERGE</b>: Resolve conflicts with the Automerge conflict resolution strategy.</para></li><li><para><b>LAMBDA</b>: Resolve conflicts with a Lambda function supplied in the LambdaConflictHandlerConfig.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.AppSync.ConflictHandlerType")]
        public Amazon.AppSync.ConflictHandlerType SyncConfig_ConflictHandler { get; set; }
        #endregion
        
        #region Parameter DataSourceName
        /// <summary>
        /// <para>
        /// <para>The name of the data source for which the resolver is being created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String DataSourceName { get; set; }
        #endregion
        
        #region Parameter FieldName
        /// <summary>
        /// <para>
        /// <para>The name of the field to attach the resolver to.</para>
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
        public System.String FieldName { get; set; }
        #endregion
        
        #region Parameter PipelineConfig_Function
        /// <summary>
        /// <para>
        /// <para>A list of <code>Function</code> objects.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PipelineConfig_Functions")]
        public System.String[] PipelineConfig_Function { get; set; }
        #endregion
        
        #region Parameter Kind
        /// <summary>
        /// <para>
        /// <para>The resolver type.</para><ul><li><para><b>UNIT</b>: A UNIT resolver type. A UNIT resolver is the default resolver type.
        /// A UNIT resolver enables you to execute a GraphQL query against a single data source.</para></li><li><para><b>PIPELINE</b>: A PIPELINE resolver type. A PIPELINE resolver enables you to execute
        /// a series of <code>Function</code> in a serial manner. You can use a pipeline resolver
        /// to execute a GraphQL query against multiple data sources.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.AppSync.ResolverKind")]
        public Amazon.AppSync.ResolverKind Kind { get; set; }
        #endregion
        
        #region Parameter LambdaConflictHandlerConfig_LambdaConflictHandlerArn
        /// <summary>
        /// <para>
        /// <para>The Arn for the Lambda function to use as the Conflict Handler.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SyncConfig_LambdaConflictHandlerConfig_LambdaConflictHandlerArn")]
        public System.String LambdaConflictHandlerConfig_LambdaConflictHandlerArn { get; set; }
        #endregion
        
        #region Parameter RequestMappingTemplate
        /// <summary>
        /// <para>
        /// <para>The mapping template to be used for requests.</para><para>A resolver uses a request mapping template to convert a GraphQL expression into a
        /// format that a data source can understand. Mapping templates are written in Apache
        /// Velocity Template Language (VTL).</para><para>VTL request mapping templates are optional when using a Lambda data source. For all
        /// other data sources, VTL request and response mapping templates are required.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RequestMappingTemplate { get; set; }
        #endregion
        
        #region Parameter ResponseMappingTemplate
        /// <summary>
        /// <para>
        /// <para>The mapping template to be used for responses from the data source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResponseMappingTemplate { get; set; }
        #endregion
        
        #region Parameter CachingConfig_Ttl
        /// <summary>
        /// <para>
        /// <para>The TTL in seconds for a resolver that has caching enabled.</para><para>Valid values are between 1 and 3600 seconds.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? CachingConfig_Ttl { get; set; }
        #endregion
        
        #region Parameter TypeName
        /// <summary>
        /// <para>
        /// <para>The name of the <code>Type</code>.</para>
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
        public System.String TypeName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Resolver'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppSync.Model.CreateResolverResponse).
        /// Specifying the name of a property of type Amazon.AppSync.Model.CreateResolverResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Resolver";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DataSourceName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DataSourceName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DataSourceName' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DataSourceName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ASYNResolver (CreateResolver)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppSync.Model.CreateResolverResponse, NewASYNResolverCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DataSourceName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ApiId = this.ApiId;
            #if MODULAR
            if (this.ApiId == null && ParameterWasBound(nameof(this.ApiId)))
            {
                WriteWarning("You are passing $null as a value for parameter ApiId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.CachingConfig_CachingKey != null)
            {
                context.CachingConfig_CachingKey = new List<System.String>(this.CachingConfig_CachingKey);
            }
            context.CachingConfig_Ttl = this.CachingConfig_Ttl;
            context.DataSourceName = this.DataSourceName;
            context.FieldName = this.FieldName;
            #if MODULAR
            if (this.FieldName == null && ParameterWasBound(nameof(this.FieldName)))
            {
                WriteWarning("You are passing $null as a value for parameter FieldName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Kind = this.Kind;
            if (this.PipelineConfig_Function != null)
            {
                context.PipelineConfig_Function = new List<System.String>(this.PipelineConfig_Function);
            }
            context.RequestMappingTemplate = this.RequestMappingTemplate;
            context.ResponseMappingTemplate = this.ResponseMappingTemplate;
            context.SyncConfig_ConflictDetection = this.SyncConfig_ConflictDetection;
            context.SyncConfig_ConflictHandler = this.SyncConfig_ConflictHandler;
            context.LambdaConflictHandlerConfig_LambdaConflictHandlerArn = this.LambdaConflictHandlerConfig_LambdaConflictHandlerArn;
            context.TypeName = this.TypeName;
            #if MODULAR
            if (this.TypeName == null && ParameterWasBound(nameof(this.TypeName)))
            {
                WriteWarning("You are passing $null as a value for parameter TypeName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AppSync.Model.CreateResolverRequest();
            
            if (cmdletContext.ApiId != null)
            {
                request.ApiId = cmdletContext.ApiId;
            }
            
             // populate CachingConfig
            var requestCachingConfigIsNull = true;
            request.CachingConfig = new Amazon.AppSync.Model.CachingConfig();
            List<System.String> requestCachingConfig_cachingConfig_CachingKey = null;
            if (cmdletContext.CachingConfig_CachingKey != null)
            {
                requestCachingConfig_cachingConfig_CachingKey = cmdletContext.CachingConfig_CachingKey;
            }
            if (requestCachingConfig_cachingConfig_CachingKey != null)
            {
                request.CachingConfig.CachingKeys = requestCachingConfig_cachingConfig_CachingKey;
                requestCachingConfigIsNull = false;
            }
            System.Int64? requestCachingConfig_cachingConfig_Ttl = null;
            if (cmdletContext.CachingConfig_Ttl != null)
            {
                requestCachingConfig_cachingConfig_Ttl = cmdletContext.CachingConfig_Ttl.Value;
            }
            if (requestCachingConfig_cachingConfig_Ttl != null)
            {
                request.CachingConfig.Ttl = requestCachingConfig_cachingConfig_Ttl.Value;
                requestCachingConfigIsNull = false;
            }
             // determine if request.CachingConfig should be set to null
            if (requestCachingConfigIsNull)
            {
                request.CachingConfig = null;
            }
            if (cmdletContext.DataSourceName != null)
            {
                request.DataSourceName = cmdletContext.DataSourceName;
            }
            if (cmdletContext.FieldName != null)
            {
                request.FieldName = cmdletContext.FieldName;
            }
            if (cmdletContext.Kind != null)
            {
                request.Kind = cmdletContext.Kind;
            }
            
             // populate PipelineConfig
            var requestPipelineConfigIsNull = true;
            request.PipelineConfig = new Amazon.AppSync.Model.PipelineConfig();
            List<System.String> requestPipelineConfig_pipelineConfig_Function = null;
            if (cmdletContext.PipelineConfig_Function != null)
            {
                requestPipelineConfig_pipelineConfig_Function = cmdletContext.PipelineConfig_Function;
            }
            if (requestPipelineConfig_pipelineConfig_Function != null)
            {
                request.PipelineConfig.Functions = requestPipelineConfig_pipelineConfig_Function;
                requestPipelineConfigIsNull = false;
            }
             // determine if request.PipelineConfig should be set to null
            if (requestPipelineConfigIsNull)
            {
                request.PipelineConfig = null;
            }
            if (cmdletContext.RequestMappingTemplate != null)
            {
                request.RequestMappingTemplate = cmdletContext.RequestMappingTemplate;
            }
            if (cmdletContext.ResponseMappingTemplate != null)
            {
                request.ResponseMappingTemplate = cmdletContext.ResponseMappingTemplate;
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
            if (cmdletContext.TypeName != null)
            {
                request.TypeName = cmdletContext.TypeName;
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
        
        private Amazon.AppSync.Model.CreateResolverResponse CallAWSServiceOperation(IAmazonAppSync client, Amazon.AppSync.Model.CreateResolverRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS AppSync", "CreateResolver");
            try
            {
                #if DESKTOP
                return client.CreateResolver(request);
                #elif CORECLR
                return client.CreateResolverAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> CachingConfig_CachingKey { get; set; }
            public System.Int64? CachingConfig_Ttl { get; set; }
            public System.String DataSourceName { get; set; }
            public System.String FieldName { get; set; }
            public Amazon.AppSync.ResolverKind Kind { get; set; }
            public List<System.String> PipelineConfig_Function { get; set; }
            public System.String RequestMappingTemplate { get; set; }
            public System.String ResponseMappingTemplate { get; set; }
            public Amazon.AppSync.ConflictDetectionType SyncConfig_ConflictDetection { get; set; }
            public Amazon.AppSync.ConflictHandlerType SyncConfig_ConflictHandler { get; set; }
            public System.String LambdaConflictHandlerConfig_LambdaConflictHandlerArn { get; set; }
            public System.String TypeName { get; set; }
            public System.Func<Amazon.AppSync.Model.CreateResolverResponse, NewASYNResolverCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Resolver;
        }
        
    }
}
