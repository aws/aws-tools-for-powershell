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
using Amazon.MailManager;
using Amazon.MailManager.Model;

namespace Amazon.PowerShell.Cmdlets.MMGR
{
    /// <summary>
    /// Creates a new email archive resource for storing and retaining emails.
    /// </summary>
    [Cmdlet("New", "MMGRArchive", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SES Mail Manager CreateArchive API operation.", Operation = new[] {"CreateArchive"}, SelectReturnType = typeof(Amazon.MailManager.Model.CreateArchiveResponse))]
    [AWSCmdletOutput("System.String or Amazon.MailManager.Model.CreateArchiveResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.MailManager.Model.CreateArchiveResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewMMGRArchiveCmdlet : AmazonMailManagerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ArchiveName
        /// <summary>
        /// <para>
        /// <para>A unique name for the new archive.</para>
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
        public System.String ArchiveName { get; set; }
        #endregion
        
        #region Parameter KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the KMS key for encrypting emails in the archive.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter Retention_RetentionPeriod
        /// <summary>
        /// <para>
        /// <para>The enum value sets the period for retaining emails in an archive.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MailManager.RetentionPeriod")]
        public Amazon.MailManager.RetentionPeriod Retention_RetentionPeriod { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags used to organize, track, or control access for the resource. For example,
        /// { "tags": {"key1":"value1", "key2":"value2"} }.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.MailManager.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique token Amazon SES uses to recognize retries of this request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ArchiveId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MailManager.Model.CreateArchiveResponse).
        /// Specifying the name of a property of type Amazon.MailManager.Model.CreateArchiveResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ArchiveId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ArchiveName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-MMGRArchive (CreateArchive)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MailManager.Model.CreateArchiveResponse, NewMMGRArchiveCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ArchiveName = this.ArchiveName;
            #if MODULAR
            if (this.ArchiveName == null && ParameterWasBound(nameof(this.ArchiveName)))
            {
                WriteWarning("You are passing $null as a value for parameter ArchiveName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.KmsKeyArn = this.KmsKeyArn;
            context.Retention_RetentionPeriod = this.Retention_RetentionPeriod;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.MailManager.Model.Tag>(this.Tag);
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
            var request = new Amazon.MailManager.Model.CreateArchiveRequest();
            
            if (cmdletContext.ArchiveName != null)
            {
                request.ArchiveName = cmdletContext.ArchiveName;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.KmsKeyArn != null)
            {
                request.KmsKeyArn = cmdletContext.KmsKeyArn;
            }
            
             // populate Retention
            var requestRetentionIsNull = true;
            request.Retention = new Amazon.MailManager.Model.ArchiveRetention();
            Amazon.MailManager.RetentionPeriod requestRetention_retention_RetentionPeriod = null;
            if (cmdletContext.Retention_RetentionPeriod != null)
            {
                requestRetention_retention_RetentionPeriod = cmdletContext.Retention_RetentionPeriod;
            }
            if (requestRetention_retention_RetentionPeriod != null)
            {
                request.Retention.RetentionPeriod = requestRetention_retention_RetentionPeriod;
                requestRetentionIsNull = false;
            }
             // determine if request.Retention should be set to null
            if (requestRetentionIsNull)
            {
                request.Retention = null;
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
        
        private Amazon.MailManager.Model.CreateArchiveResponse CallAWSServiceOperation(IAmazonMailManager client, Amazon.MailManager.Model.CreateArchiveRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SES Mail Manager", "CreateArchive");
            try
            {
                #if DESKTOP
                return client.CreateArchive(request);
                #elif CORECLR
                return client.CreateArchiveAsync(request).GetAwaiter().GetResult();
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
            public System.String ArchiveName { get; set; }
            public System.String ClientToken { get; set; }
            public System.String KmsKeyArn { get; set; }
            public Amazon.MailManager.RetentionPeriod Retention_RetentionPeriod { get; set; }
            public List<Amazon.MailManager.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.MailManager.Model.CreateArchiveResponse, NewMMGRArchiveCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ArchiveId;
        }
        
    }
}
