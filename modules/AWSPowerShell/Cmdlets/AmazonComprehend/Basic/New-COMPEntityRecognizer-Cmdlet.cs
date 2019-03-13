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
using Amazon.Comprehend;
using Amazon.Comprehend.Model;

namespace Amazon.PowerShell.Cmdlets.COMP
{
    /// <summary>
    /// Creates an entity recognizer using submitted files. After your <code>CreateEntityRecognizer</code>
    /// request is submitted, you can check job status using the API.
    /// </summary>
    [Cmdlet("New", "COMPEntityRecognizer", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Comprehend CreateEntityRecognizer API operation.", Operation = new[] {"CreateEntityRecognizer"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.Comprehend.Model.CreateEntityRecognizerResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewCOMPEntityRecognizerCmdlet : AmazonComprehendClientCmdlet, IExecutor
    {
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para> A unique identifier for the request. If you don't set the client request token, Amazon
        /// Comprehend generates one.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter DataAccessRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the AWS Identity and Management (IAM) role that
        /// grants Amazon Comprehend read access to your input data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DataAccessRoleArn { get; set; }
        #endregion
        
        #region Parameter InputDataConfig_EntityType
        /// <summary>
        /// <para>
        /// <para>The entity types in the input data for an entity recognizer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("InputDataConfig_EntityTypes")]
        public Amazon.Comprehend.Model.EntityTypesListItem[] InputDataConfig_EntityType { get; set; }
        #endregion
        
        #region Parameter LanguageCode
        /// <summary>
        /// <para>
        /// <para> The language of the input documents. All documents must be in the same language.
        /// Only English ("en") is currently supported. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Comprehend.LanguageCode")]
        public Amazon.Comprehend.LanguageCode LanguageCode { get; set; }
        #endregion
        
        #region Parameter RecognizerName
        /// <summary>
        /// <para>
        /// <para>The name given to the newly created recognizer. Recognizer names can be a maximum
        /// of 256 characters. Alphanumeric characters, hyphens (-) and underscores (_) are allowed.
        /// The name must be unique in the account/region.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String RecognizerName { get; set; }
        #endregion
        
        #region Parameter Annotations_S3Uri
        /// <summary>
        /// <para>
        /// <para> Specifies the Amazon S3 location where the annotations for an entity recognizer are
        /// located. The URI must be in the same region as the API endpoint that you are calling.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("InputDataConfig_Annotations_S3Uri")]
        public System.String Annotations_S3Uri { get; set; }
        #endregion
        
        #region Parameter Documents_S3Uri
        /// <summary>
        /// <para>
        /// <para> Specifies the Amazon S3 location where the training documents for an entity recognizer
        /// are located. The URI must be in the same region as the API endpoint that you are calling.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("InputDataConfig_Documents_S3Uri")]
        public System.String Documents_S3Uri { get; set; }
        #endregion
        
        #region Parameter EntityList_S3Uri
        /// <summary>
        /// <para>
        /// <para>Specifies the Amazon S3 location where the entity list is located. The URI must be
        /// in the same region as the API endpoint that you are calling.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("InputDataConfig_EntityList_S3Uri")]
        public System.String EntityList_S3Uri { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("RecognizerName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-COMPEntityRecognizer (CreateEntityRecognizer)"))
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
            
            context.ClientRequestToken = this.ClientRequestToken;
            context.DataAccessRoleArn = this.DataAccessRoleArn;
            context.InputDataConfig_Annotations_S3Uri = this.Annotations_S3Uri;
            context.InputDataConfig_Documents_S3Uri = this.Documents_S3Uri;
            context.InputDataConfig_EntityList_S3Uri = this.EntityList_S3Uri;
            if (this.InputDataConfig_EntityType != null)
            {
                context.InputDataConfig_EntityTypes = new List<Amazon.Comprehend.Model.EntityTypesListItem>(this.InputDataConfig_EntityType);
            }
            context.LanguageCode = this.LanguageCode;
            context.RecognizerName = this.RecognizerName;
            
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
            var request = new Amazon.Comprehend.Model.CreateEntityRecognizerRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.DataAccessRoleArn != null)
            {
                request.DataAccessRoleArn = cmdletContext.DataAccessRoleArn;
            }
            
             // populate InputDataConfig
            bool requestInputDataConfigIsNull = true;
            request.InputDataConfig = new Amazon.Comprehend.Model.EntityRecognizerInputDataConfig();
            List<Amazon.Comprehend.Model.EntityTypesListItem> requestInputDataConfig_inputDataConfig_EntityType = null;
            if (cmdletContext.InputDataConfig_EntityTypes != null)
            {
                requestInputDataConfig_inputDataConfig_EntityType = cmdletContext.InputDataConfig_EntityTypes;
            }
            if (requestInputDataConfig_inputDataConfig_EntityType != null)
            {
                request.InputDataConfig.EntityTypes = requestInputDataConfig_inputDataConfig_EntityType;
                requestInputDataConfigIsNull = false;
            }
            Amazon.Comprehend.Model.EntityRecognizerAnnotations requestInputDataConfig_inputDataConfig_Annotations = null;
            
             // populate Annotations
            bool requestInputDataConfig_inputDataConfig_AnnotationsIsNull = true;
            requestInputDataConfig_inputDataConfig_Annotations = new Amazon.Comprehend.Model.EntityRecognizerAnnotations();
            System.String requestInputDataConfig_inputDataConfig_Annotations_annotations_S3Uri = null;
            if (cmdletContext.InputDataConfig_Annotations_S3Uri != null)
            {
                requestInputDataConfig_inputDataConfig_Annotations_annotations_S3Uri = cmdletContext.InputDataConfig_Annotations_S3Uri;
            }
            if (requestInputDataConfig_inputDataConfig_Annotations_annotations_S3Uri != null)
            {
                requestInputDataConfig_inputDataConfig_Annotations.S3Uri = requestInputDataConfig_inputDataConfig_Annotations_annotations_S3Uri;
                requestInputDataConfig_inputDataConfig_AnnotationsIsNull = false;
            }
             // determine if requestInputDataConfig_inputDataConfig_Annotations should be set to null
            if (requestInputDataConfig_inputDataConfig_AnnotationsIsNull)
            {
                requestInputDataConfig_inputDataConfig_Annotations = null;
            }
            if (requestInputDataConfig_inputDataConfig_Annotations != null)
            {
                request.InputDataConfig.Annotations = requestInputDataConfig_inputDataConfig_Annotations;
                requestInputDataConfigIsNull = false;
            }
            Amazon.Comprehend.Model.EntityRecognizerDocuments requestInputDataConfig_inputDataConfig_Documents = null;
            
             // populate Documents
            bool requestInputDataConfig_inputDataConfig_DocumentsIsNull = true;
            requestInputDataConfig_inputDataConfig_Documents = new Amazon.Comprehend.Model.EntityRecognizerDocuments();
            System.String requestInputDataConfig_inputDataConfig_Documents_documents_S3Uri = null;
            if (cmdletContext.InputDataConfig_Documents_S3Uri != null)
            {
                requestInputDataConfig_inputDataConfig_Documents_documents_S3Uri = cmdletContext.InputDataConfig_Documents_S3Uri;
            }
            if (requestInputDataConfig_inputDataConfig_Documents_documents_S3Uri != null)
            {
                requestInputDataConfig_inputDataConfig_Documents.S3Uri = requestInputDataConfig_inputDataConfig_Documents_documents_S3Uri;
                requestInputDataConfig_inputDataConfig_DocumentsIsNull = false;
            }
             // determine if requestInputDataConfig_inputDataConfig_Documents should be set to null
            if (requestInputDataConfig_inputDataConfig_DocumentsIsNull)
            {
                requestInputDataConfig_inputDataConfig_Documents = null;
            }
            if (requestInputDataConfig_inputDataConfig_Documents != null)
            {
                request.InputDataConfig.Documents = requestInputDataConfig_inputDataConfig_Documents;
                requestInputDataConfigIsNull = false;
            }
            Amazon.Comprehend.Model.EntityRecognizerEntityList requestInputDataConfig_inputDataConfig_EntityList = null;
            
             // populate EntityList
            bool requestInputDataConfig_inputDataConfig_EntityListIsNull = true;
            requestInputDataConfig_inputDataConfig_EntityList = new Amazon.Comprehend.Model.EntityRecognizerEntityList();
            System.String requestInputDataConfig_inputDataConfig_EntityList_entityList_S3Uri = null;
            if (cmdletContext.InputDataConfig_EntityList_S3Uri != null)
            {
                requestInputDataConfig_inputDataConfig_EntityList_entityList_S3Uri = cmdletContext.InputDataConfig_EntityList_S3Uri;
            }
            if (requestInputDataConfig_inputDataConfig_EntityList_entityList_S3Uri != null)
            {
                requestInputDataConfig_inputDataConfig_EntityList.S3Uri = requestInputDataConfig_inputDataConfig_EntityList_entityList_S3Uri;
                requestInputDataConfig_inputDataConfig_EntityListIsNull = false;
            }
             // determine if requestInputDataConfig_inputDataConfig_EntityList should be set to null
            if (requestInputDataConfig_inputDataConfig_EntityListIsNull)
            {
                requestInputDataConfig_inputDataConfig_EntityList = null;
            }
            if (requestInputDataConfig_inputDataConfig_EntityList != null)
            {
                request.InputDataConfig.EntityList = requestInputDataConfig_inputDataConfig_EntityList;
                requestInputDataConfigIsNull = false;
            }
             // determine if request.InputDataConfig should be set to null
            if (requestInputDataConfigIsNull)
            {
                request.InputDataConfig = null;
            }
            if (cmdletContext.LanguageCode != null)
            {
                request.LanguageCode = cmdletContext.LanguageCode;
            }
            if (cmdletContext.RecognizerName != null)
            {
                request.RecognizerName = cmdletContext.RecognizerName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.EntityRecognizerArn;
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
        
        private Amazon.Comprehend.Model.CreateEntityRecognizerResponse CallAWSServiceOperation(IAmazonComprehend client, Amazon.Comprehend.Model.CreateEntityRecognizerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Comprehend", "CreateEntityRecognizer");
            try
            {
                #if DESKTOP
                return client.CreateEntityRecognizer(request);
                #elif CORECLR
                return client.CreateEntityRecognizerAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientRequestToken { get; set; }
            public System.String DataAccessRoleArn { get; set; }
            public System.String InputDataConfig_Annotations_S3Uri { get; set; }
            public System.String InputDataConfig_Documents_S3Uri { get; set; }
            public System.String InputDataConfig_EntityList_S3Uri { get; set; }
            public List<Amazon.Comprehend.Model.EntityTypesListItem> InputDataConfig_EntityTypes { get; set; }
            public Amazon.Comprehend.LanguageCode LanguageCode { get; set; }
            public System.String RecognizerName { get; set; }
        }
        
    }
}
