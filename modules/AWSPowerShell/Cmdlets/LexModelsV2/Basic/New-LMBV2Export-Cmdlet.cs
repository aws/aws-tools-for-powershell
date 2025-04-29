/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Threading;
using Amazon.LexModelsV2;
using Amazon.LexModelsV2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.LMBV2
{
    /// <summary>
    /// Creates a zip archive containing the contents of a bot or a bot locale. The archive
    /// contains a directory structure that contains JSON files that define the bot.
    /// 
    ///  
    /// <para>
    /// You can create an archive that contains the complete definition of a bot, or you can
    /// specify that the archive contain only the definition of a single bot locale.
    /// </para><para>
    /// For more information about exporting bots, and about the structure of the export archive,
    /// see <a href="https://docs.aws.amazon.com/lexv2/latest/dg/importing-exporting.html">
    /// Importing and exporting bots </a></para>
    /// </summary>
    [Cmdlet("New", "LMBV2Export", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.LexModelsV2.Model.CreateExportResponse")]
    [AWSCmdlet("Calls the Amazon Lex Model Building V2 CreateExport API operation.", Operation = new[] {"CreateExport"}, SelectReturnType = typeof(Amazon.LexModelsV2.Model.CreateExportResponse))]
    [AWSCmdletOutput("Amazon.LexModelsV2.Model.CreateExportResponse",
        "This cmdlet returns an Amazon.LexModelsV2.Model.CreateExportResponse object containing multiple properties."
    )]
    public partial class NewLMBV2ExportCmdlet : AmazonLexModelsV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter BotExportSpecification_BotId
        /// <summary>
        /// <para>
        /// <para>The identifier of the bot assigned by Amazon Lex.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceSpecification_BotExportSpecification_BotId")]
        public System.String BotExportSpecification_BotId { get; set; }
        #endregion
        
        #region Parameter BotLocaleExportSpecification_BotId
        /// <summary>
        /// <para>
        /// <para>The identifier of the bot to create the locale for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceSpecification_BotLocaleExportSpecification_BotId")]
        public System.String BotLocaleExportSpecification_BotId { get; set; }
        #endregion
        
        #region Parameter CustomVocabularyExportSpecification_BotId
        /// <summary>
        /// <para>
        /// <para>The identifier of the bot that contains the custom vocabulary to export.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceSpecification_CustomVocabularyExportSpecification_BotId")]
        public System.String CustomVocabularyExportSpecification_BotId { get; set; }
        #endregion
        
        #region Parameter BotExportSpecification_BotVersion
        /// <summary>
        /// <para>
        /// <para>The version of the bot that was exported. This will be either <c>DRAFT</c> or the
        /// version number.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceSpecification_BotExportSpecification_BotVersion")]
        public System.String BotExportSpecification_BotVersion { get; set; }
        #endregion
        
        #region Parameter BotLocaleExportSpecification_BotVersion
        /// <summary>
        /// <para>
        /// <para>The version of the bot to export.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceSpecification_BotLocaleExportSpecification_BotVersion")]
        public System.String BotLocaleExportSpecification_BotVersion { get; set; }
        #endregion
        
        #region Parameter CustomVocabularyExportSpecification_BotVersion
        /// <summary>
        /// <para>
        /// <para>The version of the bot that contains the custom vocabulary to export.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceSpecification_CustomVocabularyExportSpecification_BotVersion")]
        public System.String CustomVocabularyExportSpecification_BotVersion { get; set; }
        #endregion
        
        #region Parameter FileFormat
        /// <summary>
        /// <para>
        /// <para>The file format of the bot or bot locale definition files.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.LexModelsV2.ImportExportFileFormat")]
        public Amazon.LexModelsV2.ImportExportFileFormat FileFormat { get; set; }
        #endregion
        
        #region Parameter FilePassword
        /// <summary>
        /// <para>
        /// <para>An password to use to encrypt the exported archive. Using a password is optional,
        /// but you should encrypt the archive to protect the data in transit between Amazon Lex
        /// and your local computer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FilePassword { get; set; }
        #endregion
        
        #region Parameter BotLocaleExportSpecification_LocaleId
        /// <summary>
        /// <para>
        /// <para>The identifier of the language and locale to export. The string must match one of
        /// the locales in the bot.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceSpecification_BotLocaleExportSpecification_LocaleId")]
        public System.String BotLocaleExportSpecification_LocaleId { get; set; }
        #endregion
        
        #region Parameter CustomVocabularyExportSpecification_LocaleId
        /// <summary>
        /// <para>
        /// <para>The locale of the bot that contains the custom vocabulary to export.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceSpecification_CustomVocabularyExportSpecification_LocaleId")]
        public System.String CustomVocabularyExportSpecification_LocaleId { get; set; }
        #endregion
        
        #region Parameter TestSetExportSpecification_TestSetId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the test set.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceSpecification_TestSetExportSpecification_TestSetId")]
        public System.String TestSetExportSpecification_TestSetId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LexModelsV2.Model.CreateExportResponse).
        /// Specifying the name of a property of type Amazon.LexModelsV2.Model.CreateExportResponse will result in that property being returned.
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-LMBV2Export (CreateExport)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LexModelsV2.Model.CreateExportResponse, NewLMBV2ExportCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.FileFormat = this.FileFormat;
            #if MODULAR
            if (this.FileFormat == null && ParameterWasBound(nameof(this.FileFormat)))
            {
                WriteWarning("You are passing $null as a value for parameter FileFormat which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FilePassword = this.FilePassword;
            context.BotExportSpecification_BotId = this.BotExportSpecification_BotId;
            context.BotExportSpecification_BotVersion = this.BotExportSpecification_BotVersion;
            context.BotLocaleExportSpecification_BotId = this.BotLocaleExportSpecification_BotId;
            context.BotLocaleExportSpecification_BotVersion = this.BotLocaleExportSpecification_BotVersion;
            context.BotLocaleExportSpecification_LocaleId = this.BotLocaleExportSpecification_LocaleId;
            context.CustomVocabularyExportSpecification_BotId = this.CustomVocabularyExportSpecification_BotId;
            context.CustomVocabularyExportSpecification_BotVersion = this.CustomVocabularyExportSpecification_BotVersion;
            context.CustomVocabularyExportSpecification_LocaleId = this.CustomVocabularyExportSpecification_LocaleId;
            context.TestSetExportSpecification_TestSetId = this.TestSetExportSpecification_TestSetId;
            
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
            var request = new Amazon.LexModelsV2.Model.CreateExportRequest();
            
            if (cmdletContext.FileFormat != null)
            {
                request.FileFormat = cmdletContext.FileFormat;
            }
            if (cmdletContext.FilePassword != null)
            {
                request.FilePassword = cmdletContext.FilePassword;
            }
            
             // populate ResourceSpecification
            var requestResourceSpecificationIsNull = true;
            request.ResourceSpecification = new Amazon.LexModelsV2.Model.ExportResourceSpecification();
            Amazon.LexModelsV2.Model.TestSetExportSpecification requestResourceSpecification_resourceSpecification_TestSetExportSpecification = null;
            
             // populate TestSetExportSpecification
            var requestResourceSpecification_resourceSpecification_TestSetExportSpecificationIsNull = true;
            requestResourceSpecification_resourceSpecification_TestSetExportSpecification = new Amazon.LexModelsV2.Model.TestSetExportSpecification();
            System.String requestResourceSpecification_resourceSpecification_TestSetExportSpecification_testSetExportSpecification_TestSetId = null;
            if (cmdletContext.TestSetExportSpecification_TestSetId != null)
            {
                requestResourceSpecification_resourceSpecification_TestSetExportSpecification_testSetExportSpecification_TestSetId = cmdletContext.TestSetExportSpecification_TestSetId;
            }
            if (requestResourceSpecification_resourceSpecification_TestSetExportSpecification_testSetExportSpecification_TestSetId != null)
            {
                requestResourceSpecification_resourceSpecification_TestSetExportSpecification.TestSetId = requestResourceSpecification_resourceSpecification_TestSetExportSpecification_testSetExportSpecification_TestSetId;
                requestResourceSpecification_resourceSpecification_TestSetExportSpecificationIsNull = false;
            }
             // determine if requestResourceSpecification_resourceSpecification_TestSetExportSpecification should be set to null
            if (requestResourceSpecification_resourceSpecification_TestSetExportSpecificationIsNull)
            {
                requestResourceSpecification_resourceSpecification_TestSetExportSpecification = null;
            }
            if (requestResourceSpecification_resourceSpecification_TestSetExportSpecification != null)
            {
                request.ResourceSpecification.TestSetExportSpecification = requestResourceSpecification_resourceSpecification_TestSetExportSpecification;
                requestResourceSpecificationIsNull = false;
            }
            Amazon.LexModelsV2.Model.BotExportSpecification requestResourceSpecification_resourceSpecification_BotExportSpecification = null;
            
             // populate BotExportSpecification
            var requestResourceSpecification_resourceSpecification_BotExportSpecificationIsNull = true;
            requestResourceSpecification_resourceSpecification_BotExportSpecification = new Amazon.LexModelsV2.Model.BotExportSpecification();
            System.String requestResourceSpecification_resourceSpecification_BotExportSpecification_botExportSpecification_BotId = null;
            if (cmdletContext.BotExportSpecification_BotId != null)
            {
                requestResourceSpecification_resourceSpecification_BotExportSpecification_botExportSpecification_BotId = cmdletContext.BotExportSpecification_BotId;
            }
            if (requestResourceSpecification_resourceSpecification_BotExportSpecification_botExportSpecification_BotId != null)
            {
                requestResourceSpecification_resourceSpecification_BotExportSpecification.BotId = requestResourceSpecification_resourceSpecification_BotExportSpecification_botExportSpecification_BotId;
                requestResourceSpecification_resourceSpecification_BotExportSpecificationIsNull = false;
            }
            System.String requestResourceSpecification_resourceSpecification_BotExportSpecification_botExportSpecification_BotVersion = null;
            if (cmdletContext.BotExportSpecification_BotVersion != null)
            {
                requestResourceSpecification_resourceSpecification_BotExportSpecification_botExportSpecification_BotVersion = cmdletContext.BotExportSpecification_BotVersion;
            }
            if (requestResourceSpecification_resourceSpecification_BotExportSpecification_botExportSpecification_BotVersion != null)
            {
                requestResourceSpecification_resourceSpecification_BotExportSpecification.BotVersion = requestResourceSpecification_resourceSpecification_BotExportSpecification_botExportSpecification_BotVersion;
                requestResourceSpecification_resourceSpecification_BotExportSpecificationIsNull = false;
            }
             // determine if requestResourceSpecification_resourceSpecification_BotExportSpecification should be set to null
            if (requestResourceSpecification_resourceSpecification_BotExportSpecificationIsNull)
            {
                requestResourceSpecification_resourceSpecification_BotExportSpecification = null;
            }
            if (requestResourceSpecification_resourceSpecification_BotExportSpecification != null)
            {
                request.ResourceSpecification.BotExportSpecification = requestResourceSpecification_resourceSpecification_BotExportSpecification;
                requestResourceSpecificationIsNull = false;
            }
            Amazon.LexModelsV2.Model.BotLocaleExportSpecification requestResourceSpecification_resourceSpecification_BotLocaleExportSpecification = null;
            
             // populate BotLocaleExportSpecification
            var requestResourceSpecification_resourceSpecification_BotLocaleExportSpecificationIsNull = true;
            requestResourceSpecification_resourceSpecification_BotLocaleExportSpecification = new Amazon.LexModelsV2.Model.BotLocaleExportSpecification();
            System.String requestResourceSpecification_resourceSpecification_BotLocaleExportSpecification_botLocaleExportSpecification_BotId = null;
            if (cmdletContext.BotLocaleExportSpecification_BotId != null)
            {
                requestResourceSpecification_resourceSpecification_BotLocaleExportSpecification_botLocaleExportSpecification_BotId = cmdletContext.BotLocaleExportSpecification_BotId;
            }
            if (requestResourceSpecification_resourceSpecification_BotLocaleExportSpecification_botLocaleExportSpecification_BotId != null)
            {
                requestResourceSpecification_resourceSpecification_BotLocaleExportSpecification.BotId = requestResourceSpecification_resourceSpecification_BotLocaleExportSpecification_botLocaleExportSpecification_BotId;
                requestResourceSpecification_resourceSpecification_BotLocaleExportSpecificationIsNull = false;
            }
            System.String requestResourceSpecification_resourceSpecification_BotLocaleExportSpecification_botLocaleExportSpecification_BotVersion = null;
            if (cmdletContext.BotLocaleExportSpecification_BotVersion != null)
            {
                requestResourceSpecification_resourceSpecification_BotLocaleExportSpecification_botLocaleExportSpecification_BotVersion = cmdletContext.BotLocaleExportSpecification_BotVersion;
            }
            if (requestResourceSpecification_resourceSpecification_BotLocaleExportSpecification_botLocaleExportSpecification_BotVersion != null)
            {
                requestResourceSpecification_resourceSpecification_BotLocaleExportSpecification.BotVersion = requestResourceSpecification_resourceSpecification_BotLocaleExportSpecification_botLocaleExportSpecification_BotVersion;
                requestResourceSpecification_resourceSpecification_BotLocaleExportSpecificationIsNull = false;
            }
            System.String requestResourceSpecification_resourceSpecification_BotLocaleExportSpecification_botLocaleExportSpecification_LocaleId = null;
            if (cmdletContext.BotLocaleExportSpecification_LocaleId != null)
            {
                requestResourceSpecification_resourceSpecification_BotLocaleExportSpecification_botLocaleExportSpecification_LocaleId = cmdletContext.BotLocaleExportSpecification_LocaleId;
            }
            if (requestResourceSpecification_resourceSpecification_BotLocaleExportSpecification_botLocaleExportSpecification_LocaleId != null)
            {
                requestResourceSpecification_resourceSpecification_BotLocaleExportSpecification.LocaleId = requestResourceSpecification_resourceSpecification_BotLocaleExportSpecification_botLocaleExportSpecification_LocaleId;
                requestResourceSpecification_resourceSpecification_BotLocaleExportSpecificationIsNull = false;
            }
             // determine if requestResourceSpecification_resourceSpecification_BotLocaleExportSpecification should be set to null
            if (requestResourceSpecification_resourceSpecification_BotLocaleExportSpecificationIsNull)
            {
                requestResourceSpecification_resourceSpecification_BotLocaleExportSpecification = null;
            }
            if (requestResourceSpecification_resourceSpecification_BotLocaleExportSpecification != null)
            {
                request.ResourceSpecification.BotLocaleExportSpecification = requestResourceSpecification_resourceSpecification_BotLocaleExportSpecification;
                requestResourceSpecificationIsNull = false;
            }
            Amazon.LexModelsV2.Model.CustomVocabularyExportSpecification requestResourceSpecification_resourceSpecification_CustomVocabularyExportSpecification = null;
            
             // populate CustomVocabularyExportSpecification
            var requestResourceSpecification_resourceSpecification_CustomVocabularyExportSpecificationIsNull = true;
            requestResourceSpecification_resourceSpecification_CustomVocabularyExportSpecification = new Amazon.LexModelsV2.Model.CustomVocabularyExportSpecification();
            System.String requestResourceSpecification_resourceSpecification_CustomVocabularyExportSpecification_customVocabularyExportSpecification_BotId = null;
            if (cmdletContext.CustomVocabularyExportSpecification_BotId != null)
            {
                requestResourceSpecification_resourceSpecification_CustomVocabularyExportSpecification_customVocabularyExportSpecification_BotId = cmdletContext.CustomVocabularyExportSpecification_BotId;
            }
            if (requestResourceSpecification_resourceSpecification_CustomVocabularyExportSpecification_customVocabularyExportSpecification_BotId != null)
            {
                requestResourceSpecification_resourceSpecification_CustomVocabularyExportSpecification.BotId = requestResourceSpecification_resourceSpecification_CustomVocabularyExportSpecification_customVocabularyExportSpecification_BotId;
                requestResourceSpecification_resourceSpecification_CustomVocabularyExportSpecificationIsNull = false;
            }
            System.String requestResourceSpecification_resourceSpecification_CustomVocabularyExportSpecification_customVocabularyExportSpecification_BotVersion = null;
            if (cmdletContext.CustomVocabularyExportSpecification_BotVersion != null)
            {
                requestResourceSpecification_resourceSpecification_CustomVocabularyExportSpecification_customVocabularyExportSpecification_BotVersion = cmdletContext.CustomVocabularyExportSpecification_BotVersion;
            }
            if (requestResourceSpecification_resourceSpecification_CustomVocabularyExportSpecification_customVocabularyExportSpecification_BotVersion != null)
            {
                requestResourceSpecification_resourceSpecification_CustomVocabularyExportSpecification.BotVersion = requestResourceSpecification_resourceSpecification_CustomVocabularyExportSpecification_customVocabularyExportSpecification_BotVersion;
                requestResourceSpecification_resourceSpecification_CustomVocabularyExportSpecificationIsNull = false;
            }
            System.String requestResourceSpecification_resourceSpecification_CustomVocabularyExportSpecification_customVocabularyExportSpecification_LocaleId = null;
            if (cmdletContext.CustomVocabularyExportSpecification_LocaleId != null)
            {
                requestResourceSpecification_resourceSpecification_CustomVocabularyExportSpecification_customVocabularyExportSpecification_LocaleId = cmdletContext.CustomVocabularyExportSpecification_LocaleId;
            }
            if (requestResourceSpecification_resourceSpecification_CustomVocabularyExportSpecification_customVocabularyExportSpecification_LocaleId != null)
            {
                requestResourceSpecification_resourceSpecification_CustomVocabularyExportSpecification.LocaleId = requestResourceSpecification_resourceSpecification_CustomVocabularyExportSpecification_customVocabularyExportSpecification_LocaleId;
                requestResourceSpecification_resourceSpecification_CustomVocabularyExportSpecificationIsNull = false;
            }
             // determine if requestResourceSpecification_resourceSpecification_CustomVocabularyExportSpecification should be set to null
            if (requestResourceSpecification_resourceSpecification_CustomVocabularyExportSpecificationIsNull)
            {
                requestResourceSpecification_resourceSpecification_CustomVocabularyExportSpecification = null;
            }
            if (requestResourceSpecification_resourceSpecification_CustomVocabularyExportSpecification != null)
            {
                request.ResourceSpecification.CustomVocabularyExportSpecification = requestResourceSpecification_resourceSpecification_CustomVocabularyExportSpecification;
                requestResourceSpecificationIsNull = false;
            }
             // determine if request.ResourceSpecification should be set to null
            if (requestResourceSpecificationIsNull)
            {
                request.ResourceSpecification = null;
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
        
        private Amazon.LexModelsV2.Model.CreateExportResponse CallAWSServiceOperation(IAmazonLexModelsV2 client, Amazon.LexModelsV2.Model.CreateExportRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lex Model Building V2", "CreateExport");
            try
            {
                return client.CreateExportAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.LexModelsV2.ImportExportFileFormat FileFormat { get; set; }
            public System.String FilePassword { get; set; }
            public System.String BotExportSpecification_BotId { get; set; }
            public System.String BotExportSpecification_BotVersion { get; set; }
            public System.String BotLocaleExportSpecification_BotId { get; set; }
            public System.String BotLocaleExportSpecification_BotVersion { get; set; }
            public System.String BotLocaleExportSpecification_LocaleId { get; set; }
            public System.String CustomVocabularyExportSpecification_BotId { get; set; }
            public System.String CustomVocabularyExportSpecification_BotVersion { get; set; }
            public System.String CustomVocabularyExportSpecification_LocaleId { get; set; }
            public System.String TestSetExportSpecification_TestSetId { get; set; }
            public System.Func<Amazon.LexModelsV2.Model.CreateExportResponse, NewLMBV2ExportCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
