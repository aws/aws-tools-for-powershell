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
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Import hub content.
    /// </summary>
    [Cmdlet("Import", "SMHubContent", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SageMaker.Model.ImportHubContentResponse")]
    [AWSCmdlet("Calls the Amazon SageMaker Service ImportHubContent API operation.", Operation = new[] {"ImportHubContent"}, SelectReturnType = typeof(Amazon.SageMaker.Model.ImportHubContentResponse))]
    [AWSCmdletOutput("Amazon.SageMaker.Model.ImportHubContentResponse",
        "This cmdlet returns an Amazon.SageMaker.Model.ImportHubContentResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class ImportSMHubContentCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DocumentSchemaVersion
        /// <summary>
        /// <para>
        /// <para>The version of the hub content schema to import.</para>
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
        public System.String DocumentSchemaVersion { get; set; }
        #endregion
        
        #region Parameter HubContentDescription
        /// <summary>
        /// <para>
        /// <para>A description of the hub content to import.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String HubContentDescription { get; set; }
        #endregion
        
        #region Parameter HubContentDisplayName
        /// <summary>
        /// <para>
        /// <para>The display name of the hub content to import.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String HubContentDisplayName { get; set; }
        #endregion
        
        #region Parameter HubContentDocument
        /// <summary>
        /// <para>
        /// <para>The hub content document that describes information about the hub content such as
        /// type, associated containers, scripts, and more.</para>
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
        public System.String HubContentDocument { get; set; }
        #endregion
        
        #region Parameter HubContentMarkdown
        /// <summary>
        /// <para>
        /// <para>A string that provides a description of the hub content. This string can include links,
        /// tables, and standard markdown formating.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String HubContentMarkdown { get; set; }
        #endregion
        
        #region Parameter HubContentName
        /// <summary>
        /// <para>
        /// <para>The name of the hub content to import.</para>
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
        public System.String HubContentName { get; set; }
        #endregion
        
        #region Parameter HubContentSearchKeyword
        /// <summary>
        /// <para>
        /// <para>The searchable keywords of the hub content.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HubContentSearchKeywords")]
        public System.String[] HubContentSearchKeyword { get; set; }
        #endregion
        
        #region Parameter HubContentType
        /// <summary>
        /// <para>
        /// <para>The type of hub content to import.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.SageMaker.HubContentType")]
        public Amazon.SageMaker.HubContentType HubContentType { get; set; }
        #endregion
        
        #region Parameter HubContentVersion
        /// <summary>
        /// <para>
        /// <para>The version of the hub content to import.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String HubContentVersion { get; set; }
        #endregion
        
        #region Parameter HubName
        /// <summary>
        /// <para>
        /// <para>The name of the hub to import content into.</para>
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
        public System.String HubName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Any tags associated with the hub content.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.SageMaker.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.ImportHubContentResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.ImportHubContentResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.HubName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Import-SMHubContent (ImportHubContent)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.ImportHubContentResponse, ImportSMHubContentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DocumentSchemaVersion = this.DocumentSchemaVersion;
            #if MODULAR
            if (this.DocumentSchemaVersion == null && ParameterWasBound(nameof(this.DocumentSchemaVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter DocumentSchemaVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.HubContentDescription = this.HubContentDescription;
            context.HubContentDisplayName = this.HubContentDisplayName;
            context.HubContentDocument = this.HubContentDocument;
            #if MODULAR
            if (this.HubContentDocument == null && ParameterWasBound(nameof(this.HubContentDocument)))
            {
                WriteWarning("You are passing $null as a value for parameter HubContentDocument which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.HubContentMarkdown = this.HubContentMarkdown;
            context.HubContentName = this.HubContentName;
            #if MODULAR
            if (this.HubContentName == null && ParameterWasBound(nameof(this.HubContentName)))
            {
                WriteWarning("You are passing $null as a value for parameter HubContentName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.HubContentSearchKeyword != null)
            {
                context.HubContentSearchKeyword = new List<System.String>(this.HubContentSearchKeyword);
            }
            context.HubContentType = this.HubContentType;
            #if MODULAR
            if (this.HubContentType == null && ParameterWasBound(nameof(this.HubContentType)))
            {
                WriteWarning("You are passing $null as a value for parameter HubContentType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.HubContentVersion = this.HubContentVersion;
            context.HubName = this.HubName;
            #if MODULAR
            if (this.HubName == null && ParameterWasBound(nameof(this.HubName)))
            {
                WriteWarning("You are passing $null as a value for parameter HubName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.SageMaker.Model.Tag>(this.Tag);
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
            var request = new Amazon.SageMaker.Model.ImportHubContentRequest();
            
            if (cmdletContext.DocumentSchemaVersion != null)
            {
                request.DocumentSchemaVersion = cmdletContext.DocumentSchemaVersion;
            }
            if (cmdletContext.HubContentDescription != null)
            {
                request.HubContentDescription = cmdletContext.HubContentDescription;
            }
            if (cmdletContext.HubContentDisplayName != null)
            {
                request.HubContentDisplayName = cmdletContext.HubContentDisplayName;
            }
            if (cmdletContext.HubContentDocument != null)
            {
                request.HubContentDocument = cmdletContext.HubContentDocument;
            }
            if (cmdletContext.HubContentMarkdown != null)
            {
                request.HubContentMarkdown = cmdletContext.HubContentMarkdown;
            }
            if (cmdletContext.HubContentName != null)
            {
                request.HubContentName = cmdletContext.HubContentName;
            }
            if (cmdletContext.HubContentSearchKeyword != null)
            {
                request.HubContentSearchKeywords = cmdletContext.HubContentSearchKeyword;
            }
            if (cmdletContext.HubContentType != null)
            {
                request.HubContentType = cmdletContext.HubContentType;
            }
            if (cmdletContext.HubContentVersion != null)
            {
                request.HubContentVersion = cmdletContext.HubContentVersion;
            }
            if (cmdletContext.HubName != null)
            {
                request.HubName = cmdletContext.HubName;
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
        
        private Amazon.SageMaker.Model.ImportHubContentResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.ImportHubContentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "ImportHubContent");
            try
            {
                #if DESKTOP
                return client.ImportHubContent(request);
                #elif CORECLR
                return client.ImportHubContentAsync(request).GetAwaiter().GetResult();
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
            public System.String DocumentSchemaVersion { get; set; }
            public System.String HubContentDescription { get; set; }
            public System.String HubContentDisplayName { get; set; }
            public System.String HubContentDocument { get; set; }
            public System.String HubContentMarkdown { get; set; }
            public System.String HubContentName { get; set; }
            public List<System.String> HubContentSearchKeyword { get; set; }
            public Amazon.SageMaker.HubContentType HubContentType { get; set; }
            public System.String HubContentVersion { get; set; }
            public System.String HubName { get; set; }
            public List<Amazon.SageMaker.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.SageMaker.Model.ImportHubContentResponse, ImportSMHubContentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
