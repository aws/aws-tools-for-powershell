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
    /// Updates a <code>Resolver</code> object.
    /// </summary>
    [Cmdlet("Update", "ASYNResolver", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AppSync.Model.Resolver")]
    [AWSCmdlet("Calls the AWS AppSync UpdateResolver API operation.", Operation = new[] {"UpdateResolver"}, SelectReturnType = typeof(Amazon.AppSync.Model.UpdateResolverResponse))]
    [AWSCmdletOutput("Amazon.AppSync.Model.Resolver or Amazon.AppSync.Model.UpdateResolverResponse",
        "This cmdlet returns an Amazon.AppSync.Model.Resolver object.",
        "The service call response (type Amazon.AppSync.Model.UpdateResolverResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateASYNResolverCmdlet : AmazonAppSyncClientCmdlet, IExecutor
    {
        
        #region Parameter ApiId
        /// <summary>
        /// <para>
        /// <para>The API ID.</para>
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
        
        #region Parameter DataSourceName
        /// <summary>
        /// <para>
        /// <para>The new data source name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DataSourceName { get; set; }
        #endregion
        
        #region Parameter FieldName
        /// <summary>
        /// <para>
        /// <para>The new field name.</para>
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
        
        #region Parameter RequestMappingTemplate
        /// <summary>
        /// <para>
        /// <para>The new request mapping template.</para>
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
        public System.String RequestMappingTemplate { get; set; }
        #endregion
        
        #region Parameter ResponseMappingTemplate
        /// <summary>
        /// <para>
        /// <para>The new response mapping template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResponseMappingTemplate { get; set; }
        #endregion
        
        #region Parameter TypeName
        /// <summary>
        /// <para>
        /// <para>The new type name.</para>
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppSync.Model.UpdateResolverResponse).
        /// Specifying the name of a property of type Amazon.AppSync.Model.UpdateResolverResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Resolver";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the FieldName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^FieldName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^FieldName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FieldName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-ASYNResolver (UpdateResolver)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppSync.Model.UpdateResolverResponse, UpdateASYNResolverCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.FieldName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ApiId = this.ApiId;
            #if MODULAR
            if (this.ApiId == null && ParameterWasBound(nameof(this.ApiId)))
            {
                WriteWarning("You are passing $null as a value for parameter ApiId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            #if MODULAR
            if (this.RequestMappingTemplate == null && ParameterWasBound(nameof(this.RequestMappingTemplate)))
            {
                WriteWarning("You are passing $null as a value for parameter RequestMappingTemplate which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResponseMappingTemplate = this.ResponseMappingTemplate;
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
            var request = new Amazon.AppSync.Model.UpdateResolverRequest();
            
            if (cmdletContext.ApiId != null)
            {
                request.ApiId = cmdletContext.ApiId;
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
        
        private Amazon.AppSync.Model.UpdateResolverResponse CallAWSServiceOperation(IAmazonAppSync client, Amazon.AppSync.Model.UpdateResolverRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS AppSync", "UpdateResolver");
            try
            {
                #if DESKTOP
                return client.UpdateResolver(request);
                #elif CORECLR
                return client.UpdateResolverAsync(request).GetAwaiter().GetResult();
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
            public System.String DataSourceName { get; set; }
            public System.String FieldName { get; set; }
            public Amazon.AppSync.ResolverKind Kind { get; set; }
            public List<System.String> PipelineConfig_Function { get; set; }
            public System.String RequestMappingTemplate { get; set; }
            public System.String ResponseMappingTemplate { get; set; }
            public System.String TypeName { get; set; }
            public System.Func<Amazon.AppSync.Model.UpdateResolverResponse, UpdateASYNResolverCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Resolver;
        }
        
    }
}
