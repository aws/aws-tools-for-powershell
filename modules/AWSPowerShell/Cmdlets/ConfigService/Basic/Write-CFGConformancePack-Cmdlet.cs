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
using Amazon.ConfigService;
using Amazon.ConfigService.Model;

namespace Amazon.PowerShell.Cmdlets.CFG
{
    /// <summary>
    /// Creates or updates a conformance pack. A conformance pack is a collection of Config
    /// rules that can be easily deployed in an account and a region and across an organization.
    /// For information on how many conformance packs you can have per account, see <a href="https://docs.aws.amazon.com/config/latest/developerguide/configlimits.html"><b>Service Limits</b></a> in the Config Developer Guide.
    /// 
    ///  
    /// <para>
    /// This API creates a service-linked role <code>AWSServiceRoleForConfigConforms</code>
    /// in your account. The service-linked role is created only when the role does not exist
    /// in your account. 
    /// </para><note><para>
    /// You must specify only one of the follow parameters: <code>TemplateS3Uri</code>, <code>TemplateBody</code>
    /// or <code>TemplateSSMDocumentDetails</code>.
    /// </para></note>
    /// </summary>
    [Cmdlet("Write", "CFGConformancePack", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Config PutConformancePack API operation.", Operation = new[] {"PutConformancePack"}, SelectReturnType = typeof(Amazon.ConfigService.Model.PutConformancePackResponse))]
    [AWSCmdletOutput("System.String or Amazon.ConfigService.Model.PutConformancePackResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.ConfigService.Model.PutConformancePackResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteCFGConformancePackCmdlet : AmazonConfigServiceClientCmdlet, IExecutor
    {
        
        #region Parameter ConformancePackInputParameter
        /// <summary>
        /// <para>
        /// <para>A list of <code>ConformancePackInputParameter</code> objects.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConformancePackInputParameters")]
        public Amazon.ConfigService.Model.ConformancePackInputParameter[] ConformancePackInputParameter { get; set; }
        #endregion
        
        #region Parameter ConformancePackName
        /// <summary>
        /// <para>
        /// <para>The unique name of the conformance pack you want to deploy.</para>
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
        public System.String ConformancePackName { get; set; }
        #endregion
        
        #region Parameter DeliveryS3Bucket
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon S3 bucket where Config stores conformance pack templates.</para><note><para>This field is optional.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DeliveryS3Bucket { get; set; }
        #endregion
        
        #region Parameter DeliveryS3KeyPrefix
        /// <summary>
        /// <para>
        /// <para>The prefix for the Amazon S3 bucket. </para><note><para>This field is optional.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DeliveryS3KeyPrefix { get; set; }
        #endregion
        
        #region Parameter TemplateSSMDocumentDetails_DocumentName
        /// <summary>
        /// <para>
        /// <para>The name or Amazon Resource Name (ARN) of the SSM document to use to create a conformance
        /// pack. If you use the document name, Config checks only your account and Amazon Web
        /// Services Region for the SSM document. If you want to use an SSM document from another
        /// Region or account, you must provide the ARN.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TemplateSSMDocumentDetails_DocumentName { get; set; }
        #endregion
        
        #region Parameter TemplateSSMDocumentDetails_DocumentVersion
        /// <summary>
        /// <para>
        /// <para>The version of the SSM document to use to create a conformance pack. By default, Config
        /// uses the latest version.</para><note><para>This field is optional.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TemplateSSMDocumentDetails_DocumentVersion { get; set; }
        #endregion
        
        #region Parameter TemplateBody
        /// <summary>
        /// <para>
        /// <para>A string containing the full conformance pack template body. The structure containing
        /// the template body has a minimum length of 1 byte and a maximum length of 51,200 bytes.</para><note><para>You can use a YAML template with two resource types: Config rule (<code>AWS::Config::ConfigRule</code>)
        /// and remediation action (<code>AWS::Config::RemediationConfiguration</code>).</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TemplateBody { get; set; }
        #endregion
        
        #region Parameter TemplateS3Uri
        /// <summary>
        /// <para>
        /// <para>The location of the file containing the template body (<code>s3://bucketname/prefix</code>).
        /// The uri must point to a conformance pack template (max size: 300 KB) that is located
        /// in an Amazon S3 bucket in the same Region as the conformance pack. </para><note><para>You must have access to read Amazon S3 bucket.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TemplateS3Uri { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ConformancePackArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ConfigService.Model.PutConformancePackResponse).
        /// Specifying the name of a property of type Amazon.ConfigService.Model.PutConformancePackResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ConformancePackArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ConformancePackName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ConformancePackName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ConformancePackName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ConformancePackName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CFGConformancePack (PutConformancePack)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ConfigService.Model.PutConformancePackResponse, WriteCFGConformancePackCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ConformancePackName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.ConformancePackInputParameter != null)
            {
                context.ConformancePackInputParameter = new List<Amazon.ConfigService.Model.ConformancePackInputParameter>(this.ConformancePackInputParameter);
            }
            context.ConformancePackName = this.ConformancePackName;
            #if MODULAR
            if (this.ConformancePackName == null && ParameterWasBound(nameof(this.ConformancePackName)))
            {
                WriteWarning("You are passing $null as a value for parameter ConformancePackName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DeliveryS3Bucket = this.DeliveryS3Bucket;
            context.DeliveryS3KeyPrefix = this.DeliveryS3KeyPrefix;
            context.TemplateBody = this.TemplateBody;
            context.TemplateS3Uri = this.TemplateS3Uri;
            context.TemplateSSMDocumentDetails_DocumentName = this.TemplateSSMDocumentDetails_DocumentName;
            context.TemplateSSMDocumentDetails_DocumentVersion = this.TemplateSSMDocumentDetails_DocumentVersion;
            
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
            var request = new Amazon.ConfigService.Model.PutConformancePackRequest();
            
            if (cmdletContext.ConformancePackInputParameter != null)
            {
                request.ConformancePackInputParameters = cmdletContext.ConformancePackInputParameter;
            }
            if (cmdletContext.ConformancePackName != null)
            {
                request.ConformancePackName = cmdletContext.ConformancePackName;
            }
            if (cmdletContext.DeliveryS3Bucket != null)
            {
                request.DeliveryS3Bucket = cmdletContext.DeliveryS3Bucket;
            }
            if (cmdletContext.DeliveryS3KeyPrefix != null)
            {
                request.DeliveryS3KeyPrefix = cmdletContext.DeliveryS3KeyPrefix;
            }
            if (cmdletContext.TemplateBody != null)
            {
                request.TemplateBody = cmdletContext.TemplateBody;
            }
            if (cmdletContext.TemplateS3Uri != null)
            {
                request.TemplateS3Uri = cmdletContext.TemplateS3Uri;
            }
            
             // populate TemplateSSMDocumentDetails
            var requestTemplateSSMDocumentDetailsIsNull = true;
            request.TemplateSSMDocumentDetails = new Amazon.ConfigService.Model.TemplateSSMDocumentDetails();
            System.String requestTemplateSSMDocumentDetails_templateSSMDocumentDetails_DocumentName = null;
            if (cmdletContext.TemplateSSMDocumentDetails_DocumentName != null)
            {
                requestTemplateSSMDocumentDetails_templateSSMDocumentDetails_DocumentName = cmdletContext.TemplateSSMDocumentDetails_DocumentName;
            }
            if (requestTemplateSSMDocumentDetails_templateSSMDocumentDetails_DocumentName != null)
            {
                request.TemplateSSMDocumentDetails.DocumentName = requestTemplateSSMDocumentDetails_templateSSMDocumentDetails_DocumentName;
                requestTemplateSSMDocumentDetailsIsNull = false;
            }
            System.String requestTemplateSSMDocumentDetails_templateSSMDocumentDetails_DocumentVersion = null;
            if (cmdletContext.TemplateSSMDocumentDetails_DocumentVersion != null)
            {
                requestTemplateSSMDocumentDetails_templateSSMDocumentDetails_DocumentVersion = cmdletContext.TemplateSSMDocumentDetails_DocumentVersion;
            }
            if (requestTemplateSSMDocumentDetails_templateSSMDocumentDetails_DocumentVersion != null)
            {
                request.TemplateSSMDocumentDetails.DocumentVersion = requestTemplateSSMDocumentDetails_templateSSMDocumentDetails_DocumentVersion;
                requestTemplateSSMDocumentDetailsIsNull = false;
            }
             // determine if request.TemplateSSMDocumentDetails should be set to null
            if (requestTemplateSSMDocumentDetailsIsNull)
            {
                request.TemplateSSMDocumentDetails = null;
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
        
        private Amazon.ConfigService.Model.PutConformancePackResponse CallAWSServiceOperation(IAmazonConfigService client, Amazon.ConfigService.Model.PutConformancePackRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Config", "PutConformancePack");
            try
            {
                #if DESKTOP
                return client.PutConformancePack(request);
                #elif CORECLR
                return client.PutConformancePackAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.ConfigService.Model.ConformancePackInputParameter> ConformancePackInputParameter { get; set; }
            public System.String ConformancePackName { get; set; }
            public System.String DeliveryS3Bucket { get; set; }
            public System.String DeliveryS3KeyPrefix { get; set; }
            public System.String TemplateBody { get; set; }
            public System.String TemplateS3Uri { get; set; }
            public System.String TemplateSSMDocumentDetails_DocumentName { get; set; }
            public System.String TemplateSSMDocumentDetails_DocumentVersion { get; set; }
            public System.Func<Amazon.ConfigService.Model.PutConformancePackResponse, WriteCFGConformancePackCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ConformancePackArn;
        }
        
    }
}
