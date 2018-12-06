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
    [AWSCmdlet("Calls the AWS AppSync CreateResolver API operation.", Operation = new[] {"CreateResolver"})]
    [AWSCmdletOutput("Amazon.AppSync.Model.Resolver",
        "This cmdlet returns a Resolver object.",
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
        [System.Management.Automation.Parameter]
        public System.String ApiId { get; set; }
        #endregion
        
        #region Parameter DataSourceName
        /// <summary>
        /// <para>
        /// <para>The name of the data source for which the resolver is being created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String DataSourceName { get; set; }
        #endregion
        
        #region Parameter FieldName
        /// <summary>
        /// <para>
        /// <para>The name of the field to attach the resolver to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String FieldName { get; set; }
        #endregion
        
        #region Parameter PipelineConfig_Function
        /// <summary>
        /// <para>
        /// <para>A list of <code>Function</code> objects.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
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
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.AppSync.ResolverKind")]
        public Amazon.AppSync.ResolverKind Kind { get; set; }
        #endregion
        
        #region Parameter RequestMappingTemplate
        /// <summary>
        /// <para>
        /// <para>The mapping template to be used for requests.</para><para>A resolver uses a request mapping template to convert a GraphQL expression into a
        /// format that a data source can understand. Mapping templates are written in Apache
        /// Velocity Template Language (VTL).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RequestMappingTemplate { get; set; }
        #endregion
        
        #region Parameter ResponseMappingTemplate
        /// <summary>
        /// <para>
        /// <para>The mapping template to be used for responses from the data source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ResponseMappingTemplate { get; set; }
        #endregion
        
        #region Parameter TypeName
        /// <summary>
        /// <para>
        /// <para>The name of the <code>Type</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TypeName { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("DataSourceName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ASYNResolver (CreateResolver)"))
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
            
            context.ApiId = this.ApiId;
            context.DataSourceName = this.DataSourceName;
            context.FieldName = this.FieldName;
            context.Kind = this.Kind;
            if (this.PipelineConfig_Function != null)
            {
                context.PipelineConfig_Functions = new List<System.String>(this.PipelineConfig_Function);
            }
            context.RequestMappingTemplate = this.RequestMappingTemplate;
            context.ResponseMappingTemplate = this.ResponseMappingTemplate;
            context.TypeName = this.TypeName;
            
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
            bool requestPipelineConfigIsNull = true;
            request.PipelineConfig = new Amazon.AppSync.Model.PipelineConfig();
            List<System.String> requestPipelineConfig_pipelineConfig_Function = null;
            if (cmdletContext.PipelineConfig_Functions != null)
            {
                requestPipelineConfig_pipelineConfig_Function = cmdletContext.PipelineConfig_Functions;
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
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Resolver;
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
        
        private Amazon.AppSync.Model.CreateResolverResponse CallAWSServiceOperation(IAmazonAppSync client, Amazon.AppSync.Model.CreateResolverRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS AppSync", "CreateResolver");
            try
            {
                #if DESKTOP
                return client.CreateResolver(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateResolverAsync(request);
                return task.Result;
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
            public List<System.String> PipelineConfig_Functions { get; set; }
            public System.String RequestMappingTemplate { get; set; }
            public System.String ResponseMappingTemplate { get; set; }
            public System.String TypeName { get; set; }
        }
        
    }
}
