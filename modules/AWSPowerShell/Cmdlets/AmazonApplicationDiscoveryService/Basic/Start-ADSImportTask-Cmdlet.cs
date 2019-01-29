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
using Amazon.ApplicationDiscoveryService;
using Amazon.ApplicationDiscoveryService.Model;

namespace Amazon.PowerShell.Cmdlets.ADS
{
    /// <summary>
    /// Starts an import task, which allows you to import details of your on-premises environment
    /// directly into AWS without having to use the Application Discovery Service (ADS) tools
    /// such as the Discovery Connector or Discovery Agent. This gives you the option to perform
    /// migration assessment and planning directly from your imported data, including the
    /// ability to group your devices as applications and track their migration status.
    /// 
    ///  
    /// <para>
    /// To start an import request, do this:
    /// </para><ol><li><para>
    /// Download the specially formatted comma separated value (CSV) import template, which
    /// you can find here: <a href="https://s3-us-west-2.amazonaws.com/templates-7cffcf56-bd96-4b1c-b45b-a5b42f282e46/import_template.csv">https://s3-us-west-2.amazonaws.com/templates-7cffcf56-bd96-4b1c-b45b-a5b42f282e46/import_template.csv</a>.
    /// </para></li><li><para>
    /// Fill out the template with your server and application data.
    /// </para></li><li><para>
    /// Upload your import file to an Amazon S3 bucket, and make a note of it's Object URL.
    /// Your import file must be in the CSV format.
    /// </para></li><li><para>
    /// Use the console or the <code>StartImportTask</code> command with the AWS CLI or one
    /// of the AWS SDKs to import the records from your file.
    /// </para></li></ol><para>
    /// For more information, including step-by-step procedures, see <a href="http://docs.aws.amazon.com/application-discovery/latest/userguide/discovery-import.html">Migration
    /// Hub Import</a> in the <i>AWS Application Discovery Service User Guide</i>.
    /// </para><note><para>
    /// There are limits to the number of import tasks you can create (and delete) in an AWS
    /// account. For more information, see <a href="http://docs.aws.amazon.com/application-discovery/latest/userguide/ads_service_limits.html">AWS
    /// Application Discovery Service Limits</a> in the <i>AWS Application Discovery Service
    /// User Guide</i>.
    /// </para></note>
    /// </summary>
    [Cmdlet("Start", "ADSImportTask", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ApplicationDiscoveryService.Model.ImportTask")]
    [AWSCmdlet("Calls the Application Discovery Service StartImportTask API operation.", Operation = new[] {"StartImportTask"})]
    [AWSCmdletOutput("Amazon.ApplicationDiscoveryService.Model.ImportTask",
        "This cmdlet returns a ImportTask object.",
        "The service call response (type Amazon.ApplicationDiscoveryService.Model.StartImportTaskResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartADSImportTaskCmdlet : AmazonApplicationDiscoveryServiceClientCmdlet, IExecutor
    {
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>Optional. A unique token that you can provide to prevent the same import request from
        /// occurring more than once. If you don't provide a token, a token is automatically generated.</para><para>Sending more than one <code>StartImportTask</code> request with the same client request
        /// token will return information about the original import task with that client request
        /// token.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter ImportUrl
        /// <summary>
        /// <para>
        /// <para>The URL for your import file that you've uploaded to Amazon S3.</para><note><para>If you're using the AWS CLI, this URL is structured as follows: <code>s3://BucketName/ImportFileName.CSV</code></para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ImportUrl { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A descriptive name for this request. You can use this name to filter future requests
        /// related to this import task, such as identifying applications and servers that were
        /// included in this import task. We recommend that you use a meaningful name for each
        /// import task.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Name { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-ADSImportTask (StartImportTask)"))
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
            context.ImportUrl = this.ImportUrl;
            context.Name = this.Name;
            
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
            var request = new Amazon.ApplicationDiscoveryService.Model.StartImportTaskRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.ImportUrl != null)
            {
                request.ImportUrl = cmdletContext.ImportUrl;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Task;
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
        
        private Amazon.ApplicationDiscoveryService.Model.StartImportTaskResponse CallAWSServiceOperation(IAmazonApplicationDiscoveryService client, Amazon.ApplicationDiscoveryService.Model.StartImportTaskRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Application Discovery Service", "StartImportTask");
            try
            {
                #if DESKTOP
                return client.StartImportTask(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.StartImportTaskAsync(request);
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
            public System.String ClientRequestToken { get; set; }
            public System.String ImportUrl { get; set; }
            public System.String Name { get; set; }
        }
        
    }
}
