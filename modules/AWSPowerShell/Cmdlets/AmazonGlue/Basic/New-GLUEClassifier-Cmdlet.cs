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
using Amazon.Glue;
using Amazon.Glue.Model;

namespace Amazon.PowerShell.Cmdlets.GLUE
{
    /// <summary>
    /// Creates a classifier in the user's account. This may be a <code>GrokClassifier</code>,
    /// an <code>XMLClassifier</code>, or abbrev <code>JsonClassifier</code>, depending on
    /// which field of the request is present.
    /// </summary>
    [Cmdlet("New", "GLUEClassifier", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Glue CreateClassifier API operation.", Operation = new[] {"CreateClassifier"})]
    [AWSCmdletOutput("None",
        "This cmdlet does not generate any output. " +
        "The service response (type Amazon.Glue.Model.CreateClassifierResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewGLUEClassifierCmdlet : AmazonGlueClientCmdlet, IExecutor
    {
        
        #region Parameter GrokClassifier
        /// <summary>
        /// <para>
        /// <para>A <code>GrokClassifier</code> object specifying the classifier to create.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.Glue.Model.CreateGrokClassifierRequest GrokClassifier { get; set; }
        #endregion
        
        #region Parameter JsonClassifier_JsonPath
        /// <summary>
        /// <para>
        /// <para>A <code>JsonPath</code> string defining the JSON data for the classifier to classify.
        /// AWS Glue supports a subset of JsonPath, as described in <a href="https://docs.aws.amazon.com/glue/latest/dg/custom-classifier.html#custom-classifier-json">Writing
        /// JsonPath Custom Classifiers</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String JsonClassifier_JsonPath { get; set; }
        #endregion
        
        #region Parameter JsonClassifier_Name
        /// <summary>
        /// <para>
        /// <para>The name of the classifier.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String JsonClassifier_Name { get; set; }
        #endregion
        
        #region Parameter XMLClassifier
        /// <summary>
        /// <para>
        /// <para>An <code>XMLClassifier</code> object specifying the classifier to create.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.Glue.Model.CreateXMLClassifierRequest XMLClassifier { get; set; }
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GLUEClassifier (CreateClassifier)"))
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
            
            context.GrokClassifier = this.GrokClassifier;
            context.JsonClassifier_JsonPath = this.JsonClassifier_JsonPath;
            context.JsonClassifier_Name = this.JsonClassifier_Name;
            context.XMLClassifier = this.XMLClassifier;
            
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
            var request = new Amazon.Glue.Model.CreateClassifierRequest();
            
            if (cmdletContext.GrokClassifier != null)
            {
                request.GrokClassifier = cmdletContext.GrokClassifier;
            }
            
             // populate JsonClassifier
            bool requestJsonClassifierIsNull = true;
            request.JsonClassifier = new Amazon.Glue.Model.CreateJsonClassifierRequest();
            System.String requestJsonClassifier_jsonClassifier_JsonPath = null;
            if (cmdletContext.JsonClassifier_JsonPath != null)
            {
                requestJsonClassifier_jsonClassifier_JsonPath = cmdletContext.JsonClassifier_JsonPath;
            }
            if (requestJsonClassifier_jsonClassifier_JsonPath != null)
            {
                request.JsonClassifier.JsonPath = requestJsonClassifier_jsonClassifier_JsonPath;
                requestJsonClassifierIsNull = false;
            }
            System.String requestJsonClassifier_jsonClassifier_Name = null;
            if (cmdletContext.JsonClassifier_Name != null)
            {
                requestJsonClassifier_jsonClassifier_Name = cmdletContext.JsonClassifier_Name;
            }
            if (requestJsonClassifier_jsonClassifier_Name != null)
            {
                request.JsonClassifier.Name = requestJsonClassifier_jsonClassifier_Name;
                requestJsonClassifierIsNull = false;
            }
             // determine if request.JsonClassifier should be set to null
            if (requestJsonClassifierIsNull)
            {
                request.JsonClassifier = null;
            }
            if (cmdletContext.XMLClassifier != null)
            {
                request.XMLClassifier = cmdletContext.XMLClassifier;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
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
        
        private Amazon.Glue.Model.CreateClassifierResponse CallAWSServiceOperation(IAmazonGlue client, Amazon.Glue.Model.CreateClassifierRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Glue", "CreateClassifier");
            try
            {
                #if DESKTOP
                return client.CreateClassifier(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateClassifierAsync(request);
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
            public Amazon.Glue.Model.CreateGrokClassifierRequest GrokClassifier { get; set; }
            public System.String JsonClassifier_JsonPath { get; set; }
            public System.String JsonClassifier_Name { get; set; }
            public Amazon.Glue.Model.CreateXMLClassifierRequest XMLClassifier { get; set; }
        }
        
    }
}
