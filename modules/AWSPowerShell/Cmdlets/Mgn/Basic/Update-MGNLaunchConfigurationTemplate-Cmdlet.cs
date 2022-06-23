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
using Amazon.Mgn;
using Amazon.Mgn.Model;

namespace Amazon.PowerShell.Cmdlets.MGN
{
    /// <summary>
    /// Creates a new ReplicationConfigurationTemplate.
    /// </summary>
    [Cmdlet("Update", "MGNLaunchConfigurationTemplate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Mgn.Model.UpdateLaunchConfigurationTemplateResponse")]
    [AWSCmdlet("Calls the Application Migration Service UpdateLaunchConfigurationTemplate API operation.", Operation = new[] {"UpdateLaunchConfigurationTemplate"}, SelectReturnType = typeof(Amazon.Mgn.Model.UpdateLaunchConfigurationTemplateResponse))]
    [AWSCmdletOutput("Amazon.Mgn.Model.UpdateLaunchConfigurationTemplateResponse",
        "This cmdlet returns an Amazon.Mgn.Model.UpdateLaunchConfigurationTemplateResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateMGNLaunchConfigurationTemplateCmdlet : AmazonMgnClientCmdlet, IExecutor
    {
        
        #region Parameter PostLaunchActions_CloudWatchLogGroupName
        /// <summary>
        /// <para>
        /// <para>Server participating in Job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PostLaunchActions_CloudWatchLogGroupName { get; set; }
        #endregion
        
        #region Parameter PostLaunchActions_Deployment
        /// <summary>
        /// <para>
        /// <para>Server participating in Job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Mgn.PostLaunchActionsDeploymentType")]
        public Amazon.Mgn.PostLaunchActionsDeploymentType PostLaunchActions_Deployment { get; set; }
        #endregion
        
        #region Parameter LaunchConfigurationTemplateID
        /// <summary>
        /// <para>
        /// <para>Update Launch configuration Target instance right sizing request.</para>
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
        public System.String LaunchConfigurationTemplateID { get; set; }
        #endregion
        
        #region Parameter PostLaunchActions_S3LogBucket
        /// <summary>
        /// <para>
        /// <para>Server participating in Job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PostLaunchActions_S3LogBucket { get; set; }
        #endregion
        
        #region Parameter PostLaunchActions_S3OutputKeyPrefix
        /// <summary>
        /// <para>
        /// <para>Server participating in Job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PostLaunchActions_S3OutputKeyPrefix { get; set; }
        #endregion
        
        #region Parameter PostLaunchActions_SsmDocument
        /// <summary>
        /// <para>
        /// <para>Server participating in Job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PostLaunchActions_SsmDocuments")]
        public Amazon.Mgn.Model.SsmDocument[] PostLaunchActions_SsmDocument { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Mgn.Model.UpdateLaunchConfigurationTemplateResponse).
        /// Specifying the name of a property of type Amazon.Mgn.Model.UpdateLaunchConfigurationTemplateResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the LaunchConfigurationTemplateID parameter.
        /// The -PassThru parameter is deprecated, use -Select '^LaunchConfigurationTemplateID' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^LaunchConfigurationTemplateID' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PostLaunchActions_CloudWatchLogGroupName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-MGNLaunchConfigurationTemplate (UpdateLaunchConfigurationTemplate)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Mgn.Model.UpdateLaunchConfigurationTemplateResponse, UpdateMGNLaunchConfigurationTemplateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.LaunchConfigurationTemplateID;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.LaunchConfigurationTemplateID = this.LaunchConfigurationTemplateID;
            #if MODULAR
            if (this.LaunchConfigurationTemplateID == null && ParameterWasBound(nameof(this.LaunchConfigurationTemplateID)))
            {
                WriteWarning("You are passing $null as a value for parameter LaunchConfigurationTemplateID which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PostLaunchActions_CloudWatchLogGroupName = this.PostLaunchActions_CloudWatchLogGroupName;
            context.PostLaunchActions_Deployment = this.PostLaunchActions_Deployment;
            context.PostLaunchActions_S3LogBucket = this.PostLaunchActions_S3LogBucket;
            context.PostLaunchActions_S3OutputKeyPrefix = this.PostLaunchActions_S3OutputKeyPrefix;
            if (this.PostLaunchActions_SsmDocument != null)
            {
                context.PostLaunchActions_SsmDocument = new List<Amazon.Mgn.Model.SsmDocument>(this.PostLaunchActions_SsmDocument);
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
            var request = new Amazon.Mgn.Model.UpdateLaunchConfigurationTemplateRequest();
            
            if (cmdletContext.LaunchConfigurationTemplateID != null)
            {
                request.LaunchConfigurationTemplateID = cmdletContext.LaunchConfigurationTemplateID;
            }
            
             // populate PostLaunchActions
            var requestPostLaunchActionsIsNull = true;
            request.PostLaunchActions = new Amazon.Mgn.Model.PostLaunchActions();
            System.String requestPostLaunchActions_postLaunchActions_CloudWatchLogGroupName = null;
            if (cmdletContext.PostLaunchActions_CloudWatchLogGroupName != null)
            {
                requestPostLaunchActions_postLaunchActions_CloudWatchLogGroupName = cmdletContext.PostLaunchActions_CloudWatchLogGroupName;
            }
            if (requestPostLaunchActions_postLaunchActions_CloudWatchLogGroupName != null)
            {
                request.PostLaunchActions.CloudWatchLogGroupName = requestPostLaunchActions_postLaunchActions_CloudWatchLogGroupName;
                requestPostLaunchActionsIsNull = false;
            }
            Amazon.Mgn.PostLaunchActionsDeploymentType requestPostLaunchActions_postLaunchActions_Deployment = null;
            if (cmdletContext.PostLaunchActions_Deployment != null)
            {
                requestPostLaunchActions_postLaunchActions_Deployment = cmdletContext.PostLaunchActions_Deployment;
            }
            if (requestPostLaunchActions_postLaunchActions_Deployment != null)
            {
                request.PostLaunchActions.Deployment = requestPostLaunchActions_postLaunchActions_Deployment;
                requestPostLaunchActionsIsNull = false;
            }
            System.String requestPostLaunchActions_postLaunchActions_S3LogBucket = null;
            if (cmdletContext.PostLaunchActions_S3LogBucket != null)
            {
                requestPostLaunchActions_postLaunchActions_S3LogBucket = cmdletContext.PostLaunchActions_S3LogBucket;
            }
            if (requestPostLaunchActions_postLaunchActions_S3LogBucket != null)
            {
                request.PostLaunchActions.S3LogBucket = requestPostLaunchActions_postLaunchActions_S3LogBucket;
                requestPostLaunchActionsIsNull = false;
            }
            System.String requestPostLaunchActions_postLaunchActions_S3OutputKeyPrefix = null;
            if (cmdletContext.PostLaunchActions_S3OutputKeyPrefix != null)
            {
                requestPostLaunchActions_postLaunchActions_S3OutputKeyPrefix = cmdletContext.PostLaunchActions_S3OutputKeyPrefix;
            }
            if (requestPostLaunchActions_postLaunchActions_S3OutputKeyPrefix != null)
            {
                request.PostLaunchActions.S3OutputKeyPrefix = requestPostLaunchActions_postLaunchActions_S3OutputKeyPrefix;
                requestPostLaunchActionsIsNull = false;
            }
            List<Amazon.Mgn.Model.SsmDocument> requestPostLaunchActions_postLaunchActions_SsmDocument = null;
            if (cmdletContext.PostLaunchActions_SsmDocument != null)
            {
                requestPostLaunchActions_postLaunchActions_SsmDocument = cmdletContext.PostLaunchActions_SsmDocument;
            }
            if (requestPostLaunchActions_postLaunchActions_SsmDocument != null)
            {
                request.PostLaunchActions.SsmDocuments = requestPostLaunchActions_postLaunchActions_SsmDocument;
                requestPostLaunchActionsIsNull = false;
            }
             // determine if request.PostLaunchActions should be set to null
            if (requestPostLaunchActionsIsNull)
            {
                request.PostLaunchActions = null;
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
        
        private Amazon.Mgn.Model.UpdateLaunchConfigurationTemplateResponse CallAWSServiceOperation(IAmazonMgn client, Amazon.Mgn.Model.UpdateLaunchConfigurationTemplateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Application Migration Service", "UpdateLaunchConfigurationTemplate");
            try
            {
                #if DESKTOP
                return client.UpdateLaunchConfigurationTemplate(request);
                #elif CORECLR
                return client.UpdateLaunchConfigurationTemplateAsync(request).GetAwaiter().GetResult();
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
            public System.String LaunchConfigurationTemplateID { get; set; }
            public System.String PostLaunchActions_CloudWatchLogGroupName { get; set; }
            public Amazon.Mgn.PostLaunchActionsDeploymentType PostLaunchActions_Deployment { get; set; }
            public System.String PostLaunchActions_S3LogBucket { get; set; }
            public System.String PostLaunchActions_S3OutputKeyPrefix { get; set; }
            public List<Amazon.Mgn.Model.SsmDocument> PostLaunchActions_SsmDocument { get; set; }
            public System.Func<Amazon.Mgn.Model.UpdateLaunchConfigurationTemplateResponse, UpdateMGNLaunchConfigurationTemplateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
