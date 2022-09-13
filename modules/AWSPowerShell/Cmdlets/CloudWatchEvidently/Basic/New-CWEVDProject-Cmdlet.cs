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
using Amazon.CloudWatchEvidently;
using Amazon.CloudWatchEvidently.Model;

namespace Amazon.PowerShell.Cmdlets.CWEVD
{
    /// <summary>
    /// Creates a project, which is the logical object in Evidently that can contain features,
    /// launches, and experiments. Use projects to group similar features together.
    /// 
    ///  
    /// <para>
    /// To update an existing project, use <a href="https://docs.aws.amazon.com/cloudwatchevidently/latest/APIReference/API_UpdateProject.html">UpdateProject</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "CWEVDProject", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudWatchEvidently.Model.Project")]
    [AWSCmdlet("Calls the Amazon CloudWatch Evidently CreateProject API operation.", Operation = new[] {"CreateProject"}, SelectReturnType = typeof(Amazon.CloudWatchEvidently.Model.CreateProjectResponse))]
    [AWSCmdletOutput("Amazon.CloudWatchEvidently.Model.Project or Amazon.CloudWatchEvidently.Model.CreateProjectResponse",
        "This cmdlet returns an Amazon.CloudWatchEvidently.Model.Project object.",
        "The service call response (type Amazon.CloudWatchEvidently.Model.CreateProjectResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewCWEVDProjectCmdlet : AmazonCloudWatchEvidentlyClientCmdlet, IExecutor
    {
        
        #region Parameter AppConfigResource_ApplicationId
        /// <summary>
        /// <para>
        /// <para>The ID of the AppConfig application to use for client-side evaluation. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AppConfigResource_ApplicationId { get; set; }
        #endregion
        
        #region Parameter S3Destination_Bucket
        /// <summary>
        /// <para>
        /// <para>The name of the bucket in which Evidently stores evaluation events.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataDelivery_S3Destination_Bucket")]
        public System.String S3Destination_Bucket { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>An optional description of the project.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter AppConfigResource_EnvironmentId
        /// <summary>
        /// <para>
        /// <para>The ID of the AppConfig environment to use for client-side evaluation. This must be
        /// an environment that is within the application that you specify for <code>applicationId</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AppConfigResource_EnvironmentId { get; set; }
        #endregion
        
        #region Parameter CloudWatchLogs_LogGroup
        /// <summary>
        /// <para>
        /// <para>The name of the log group where the project stores evaluation events.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataDelivery_CloudWatchLogs_LogGroup")]
        public System.String CloudWatchLogs_LogGroup { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name for the project.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter S3Destination_Prefix
        /// <summary>
        /// <para>
        /// <para>The bucket prefix in which Evidently stores evaluation events.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataDelivery_S3Destination_Prefix")]
        public System.String S3Destination_Prefix { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Assigns one or more tags (key-value pairs) to the project.</para><para>Tags can help you organize and categorize your resources. You can also use them to
        /// scope user permissions by granting a user permission to access or change only resources
        /// with certain tag values.</para><para>Tags don't have any semantic meaning to Amazon Web Services and are interpreted strictly
        /// as strings of characters.</para><pre><code> &lt;p&gt;You can associate as many as 50 tags with a project.&lt;/p&gt;
        /// &lt;p&gt;For more information, see &lt;a href="https://docs.aws.amazon.com/general/latest/gr/aws_tagging.html"&gt;Tagging
        /// Amazon Web Services resources&lt;/a&gt;.&lt;/p&gt; </code></pre>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Project'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatchEvidently.Model.CreateProjectResponse).
        /// Specifying the name of a property of type Amazon.CloudWatchEvidently.Model.CreateProjectResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Project";
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CWEVDProject (CreateProject)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatchEvidently.Model.CreateProjectResponse, NewCWEVDProjectCmdlet>(Select) ??
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
            context.AppConfigResource_ApplicationId = this.AppConfigResource_ApplicationId;
            context.AppConfigResource_EnvironmentId = this.AppConfigResource_EnvironmentId;
            context.CloudWatchLogs_LogGroup = this.CloudWatchLogs_LogGroup;
            context.S3Destination_Bucket = this.S3Destination_Bucket;
            context.S3Destination_Prefix = this.S3Destination_Prefix;
            context.Description = this.Description;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.CloudWatchEvidently.Model.CreateProjectRequest();
            
            
             // populate AppConfigResource
            var requestAppConfigResourceIsNull = true;
            request.AppConfigResource = new Amazon.CloudWatchEvidently.Model.ProjectAppConfigResourceConfig();
            System.String requestAppConfigResource_appConfigResource_ApplicationId = null;
            if (cmdletContext.AppConfigResource_ApplicationId != null)
            {
                requestAppConfigResource_appConfigResource_ApplicationId = cmdletContext.AppConfigResource_ApplicationId;
            }
            if (requestAppConfigResource_appConfigResource_ApplicationId != null)
            {
                request.AppConfigResource.ApplicationId = requestAppConfigResource_appConfigResource_ApplicationId;
                requestAppConfigResourceIsNull = false;
            }
            System.String requestAppConfigResource_appConfigResource_EnvironmentId = null;
            if (cmdletContext.AppConfigResource_EnvironmentId != null)
            {
                requestAppConfigResource_appConfigResource_EnvironmentId = cmdletContext.AppConfigResource_EnvironmentId;
            }
            if (requestAppConfigResource_appConfigResource_EnvironmentId != null)
            {
                request.AppConfigResource.EnvironmentId = requestAppConfigResource_appConfigResource_EnvironmentId;
                requestAppConfigResourceIsNull = false;
            }
             // determine if request.AppConfigResource should be set to null
            if (requestAppConfigResourceIsNull)
            {
                request.AppConfigResource = null;
            }
            
             // populate DataDelivery
            var requestDataDeliveryIsNull = true;
            request.DataDelivery = new Amazon.CloudWatchEvidently.Model.ProjectDataDeliveryConfig();
            Amazon.CloudWatchEvidently.Model.CloudWatchLogsDestinationConfig requestDataDelivery_dataDelivery_CloudWatchLogs = null;
            
             // populate CloudWatchLogs
            var requestDataDelivery_dataDelivery_CloudWatchLogsIsNull = true;
            requestDataDelivery_dataDelivery_CloudWatchLogs = new Amazon.CloudWatchEvidently.Model.CloudWatchLogsDestinationConfig();
            System.String requestDataDelivery_dataDelivery_CloudWatchLogs_cloudWatchLogs_LogGroup = null;
            if (cmdletContext.CloudWatchLogs_LogGroup != null)
            {
                requestDataDelivery_dataDelivery_CloudWatchLogs_cloudWatchLogs_LogGroup = cmdletContext.CloudWatchLogs_LogGroup;
            }
            if (requestDataDelivery_dataDelivery_CloudWatchLogs_cloudWatchLogs_LogGroup != null)
            {
                requestDataDelivery_dataDelivery_CloudWatchLogs.LogGroup = requestDataDelivery_dataDelivery_CloudWatchLogs_cloudWatchLogs_LogGroup;
                requestDataDelivery_dataDelivery_CloudWatchLogsIsNull = false;
            }
             // determine if requestDataDelivery_dataDelivery_CloudWatchLogs should be set to null
            if (requestDataDelivery_dataDelivery_CloudWatchLogsIsNull)
            {
                requestDataDelivery_dataDelivery_CloudWatchLogs = null;
            }
            if (requestDataDelivery_dataDelivery_CloudWatchLogs != null)
            {
                request.DataDelivery.CloudWatchLogs = requestDataDelivery_dataDelivery_CloudWatchLogs;
                requestDataDeliveryIsNull = false;
            }
            Amazon.CloudWatchEvidently.Model.S3DestinationConfig requestDataDelivery_dataDelivery_S3Destination = null;
            
             // populate S3Destination
            var requestDataDelivery_dataDelivery_S3DestinationIsNull = true;
            requestDataDelivery_dataDelivery_S3Destination = new Amazon.CloudWatchEvidently.Model.S3DestinationConfig();
            System.String requestDataDelivery_dataDelivery_S3Destination_s3Destination_Bucket = null;
            if (cmdletContext.S3Destination_Bucket != null)
            {
                requestDataDelivery_dataDelivery_S3Destination_s3Destination_Bucket = cmdletContext.S3Destination_Bucket;
            }
            if (requestDataDelivery_dataDelivery_S3Destination_s3Destination_Bucket != null)
            {
                requestDataDelivery_dataDelivery_S3Destination.Bucket = requestDataDelivery_dataDelivery_S3Destination_s3Destination_Bucket;
                requestDataDelivery_dataDelivery_S3DestinationIsNull = false;
            }
            System.String requestDataDelivery_dataDelivery_S3Destination_s3Destination_Prefix = null;
            if (cmdletContext.S3Destination_Prefix != null)
            {
                requestDataDelivery_dataDelivery_S3Destination_s3Destination_Prefix = cmdletContext.S3Destination_Prefix;
            }
            if (requestDataDelivery_dataDelivery_S3Destination_s3Destination_Prefix != null)
            {
                requestDataDelivery_dataDelivery_S3Destination.Prefix = requestDataDelivery_dataDelivery_S3Destination_s3Destination_Prefix;
                requestDataDelivery_dataDelivery_S3DestinationIsNull = false;
            }
             // determine if requestDataDelivery_dataDelivery_S3Destination should be set to null
            if (requestDataDelivery_dataDelivery_S3DestinationIsNull)
            {
                requestDataDelivery_dataDelivery_S3Destination = null;
            }
            if (requestDataDelivery_dataDelivery_S3Destination != null)
            {
                request.DataDelivery.S3Destination = requestDataDelivery_dataDelivery_S3Destination;
                requestDataDeliveryIsNull = false;
            }
             // determine if request.DataDelivery should be set to null
            if (requestDataDeliveryIsNull)
            {
                request.DataDelivery = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
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
        
        private Amazon.CloudWatchEvidently.Model.CreateProjectResponse CallAWSServiceOperation(IAmazonCloudWatchEvidently client, Amazon.CloudWatchEvidently.Model.CreateProjectRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Evidently", "CreateProject");
            try
            {
                #if DESKTOP
                return client.CreateProject(request);
                #elif CORECLR
                return client.CreateProjectAsync(request).GetAwaiter().GetResult();
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
            public System.String AppConfigResource_ApplicationId { get; set; }
            public System.String AppConfigResource_EnvironmentId { get; set; }
            public System.String CloudWatchLogs_LogGroup { get; set; }
            public System.String S3Destination_Bucket { get; set; }
            public System.String S3Destination_Prefix { get; set; }
            public System.String Description { get; set; }
            public System.String Name { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.CloudWatchEvidently.Model.CreateProjectResponse, NewCWEVDProjectCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Project;
        }
        
    }
}
