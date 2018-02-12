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
using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;

namespace Amazon.PowerShell.Cmdlets.SSM
{
    /// <summary>
    /// Creates a Systems Manager document.
    /// 
    ///  
    /// <para>
    /// After you create a document, you can use CreateAssociation to associate it with one
    /// or more running instances.
    /// </para>
    /// </summary>
    [Cmdlet("New", "SSMDocument", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SimpleSystemsManagement.Model.DocumentDescription")]
    [AWSCmdlet("Calls the AWS Systems Manager CreateDocument API operation.", Operation = new[] {"CreateDocument"})]
    [AWSCmdletOutput("Amazon.SimpleSystemsManagement.Model.DocumentDescription",
        "This cmdlet returns a DocumentDescription object.",
        "The service call response (type Amazon.SimpleSystemsManagement.Model.CreateDocumentResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSSMDocumentCmdlet : AmazonSimpleSystemsManagementClientCmdlet, IExecutor
    {
        
        #region Parameter Content
        /// <summary>
        /// <para>
        /// <para>A valid JSON or YAML string.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Content { get; set; }
        #endregion
        
        #region Parameter DocumentFormat
        /// <summary>
        /// <para>
        /// <para>Specify the document format for the request. The document format can be either JSON
        /// or YAML. JSON is the default format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.SimpleSystemsManagement.DocumentFormat")]
        public Amazon.SimpleSystemsManagement.DocumentFormat DocumentFormat { get; set; }
        #endregion
        
        #region Parameter DocumentType
        /// <summary>
        /// <para>
        /// <para>The type of document to create. Valid document types include: Policy, Automation,
        /// and Command.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.SimpleSystemsManagement.DocumentType")]
        public Amazon.SimpleSystemsManagement.DocumentType DocumentType { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A name for the Systems Manager document.</para><important><para>Do not use the following to begin the names of documents you create. They are reserved
        /// by AWS for use as document prefixes:</para><ul><li><para><code>aws</code></para></li><li><para><code>amazon</code></para></li><li><para><code>amzn</code></para></li></ul></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter TargetType
        /// <summary>
        /// <para>
        /// <para>Specify a target type to define the kinds of resources the document can run on. For
        /// example, to run a document on EC2 instances, specify the following value: /AWS::EC2::Instance.
        /// If you specify a value of '/' the document can run on all types of resources. If you
        /// don't specify a value, the document can't run on any resources. For a list of valid
        /// resource types, see <a href="http://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/aws-template-resource-type-ref.html">AWS
        /// Resource Types Reference</a> in the <i>AWS CloudFormation User Guide</i>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TargetType { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Name", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SSMDocument (CreateDocument)"))
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
            
            context.Content = this.Content;
            context.DocumentFormat = this.DocumentFormat;
            context.DocumentType = this.DocumentType;
            context.Name = this.Name;
            context.TargetType = this.TargetType;
            
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
            var request = new Amazon.SimpleSystemsManagement.Model.CreateDocumentRequest();
            
            if (cmdletContext.Content != null)
            {
                request.Content = cmdletContext.Content;
            }
            if (cmdletContext.DocumentFormat != null)
            {
                request.DocumentFormat = cmdletContext.DocumentFormat;
            }
            if (cmdletContext.DocumentType != null)
            {
                request.DocumentType = cmdletContext.DocumentType;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.TargetType != null)
            {
                request.TargetType = cmdletContext.TargetType;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.DocumentDescription;
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
        
        private Amazon.SimpleSystemsManagement.Model.CreateDocumentResponse CallAWSServiceOperation(IAmazonSimpleSystemsManagement client, Amazon.SimpleSystemsManagement.Model.CreateDocumentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Systems Manager", "CreateDocument");
            try
            {
                #if DESKTOP
                return client.CreateDocument(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateDocumentAsync(request);
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
            public System.String Content { get; set; }
            public Amazon.SimpleSystemsManagement.DocumentFormat DocumentFormat { get; set; }
            public Amazon.SimpleSystemsManagement.DocumentType DocumentType { get; set; }
            public System.String Name { get; set; }
            public System.String TargetType { get; set; }
        }
        
    }
}
