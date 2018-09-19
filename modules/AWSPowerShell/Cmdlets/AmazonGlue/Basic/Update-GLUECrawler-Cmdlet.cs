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
    /// Updates a crawler. If a crawler is running, you must stop it using <code>StopCrawler</code>
    /// before updating it.
    /// </summary>
    [Cmdlet("Update", "GLUECrawler", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Calls the AWS Glue UpdateCrawler API operation.", Operation = new[] {"UpdateCrawler"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the Name parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.Glue.Model.UpdateCrawlerResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateGLUECrawlerCmdlet : AmazonGlueClientCmdlet, IExecutor
    {
        
        #region Parameter Classifier
        /// <summary>
        /// <para>
        /// <para>A list of custom classifiers that the user has registered. By default, all built-in
        /// classifiers are included in a crawl, but these custom classifiers always override
        /// the default classifiers for a given classification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Classifiers")]
        public System.String[] Classifier { get; set; }
        #endregion
        
        #region Parameter Configuration
        /// <summary>
        /// <para>
        /// <para>Crawler configuration information. This versioned JSON string allows users to specify
        /// aspects of a Crawler's behavior.</para><para>You can use this field to force partitions to inherit metadata such as classification,
        /// input format, output format, serde information, and schema from their parent table,
        /// rather than detect this information separately for each partition. Use the following
        /// JSON string to specify that behavior:</para><para>Example: <code>'{ "Version": 1.0, "CrawlerOutput": { "Partitions": { "AddOrUpdateBehavior":
        /// "InheritFromTable" } } }'</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Configuration { get; set; }
        #endregion
        
        #region Parameter CrawlerSecurityConfiguration
        /// <summary>
        /// <para>
        /// <para>The name of the SecurityConfiguration structure to be used by this Crawler.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CrawlerSecurityConfiguration { get; set; }
        #endregion
        
        #region Parameter DatabaseName
        /// <summary>
        /// <para>
        /// <para>The AWS Glue database where results are stored, such as: <code>arn:aws:daylight:us-east-1::database/sometable/*</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DatabaseName { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the new crawler.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Name of the new crawler.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Role
        /// <summary>
        /// <para>
        /// <para>The IAM role (or ARN of an IAM role) used by the new crawler to access customer resources.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Role { get; set; }
        #endregion
        
        #region Parameter Schedule
        /// <summary>
        /// <para>
        /// <para>A <code>cron</code> expression used to specify the schedule (see <a href="http://docs.aws.amazon.com/glue/latest/dg/monitor-data-warehouse-schedule.html">Time-Based
        /// Schedules for Jobs and Crawlers</a>. For example, to run something every day at 12:15
        /// UTC, you would specify: <code>cron(15 12 * * ? *)</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Schedule { get; set; }
        #endregion
        
        #region Parameter SchemaChangePolicy
        /// <summary>
        /// <para>
        /// <para>Policy for the crawler's update and deletion behavior.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.Glue.Model.SchemaChangePolicy SchemaChangePolicy { get; set; }
        #endregion
        
        #region Parameter TablePrefix
        /// <summary>
        /// <para>
        /// <para>The table prefix used for catalog tables that are created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TablePrefix { get; set; }
        #endregion
        
        #region Parameter Target
        /// <summary>
        /// <para>
        /// <para>A list of targets to crawl.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Targets")]
        public Amazon.Glue.Model.CrawlerTargets Target { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the Name parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-GLUECrawler (UpdateCrawler)"))
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
            
            if (this.Classifier != null)
            {
                context.Classifiers = new List<System.String>(this.Classifier);
            }
            context.Configuration = this.Configuration;
            context.CrawlerSecurityConfiguration = this.CrawlerSecurityConfiguration;
            context.DatabaseName = this.DatabaseName;
            context.Description = this.Description;
            context.Name = this.Name;
            context.Role = this.Role;
            context.Schedule = this.Schedule;
            context.SchemaChangePolicy = this.SchemaChangePolicy;
            context.TablePrefix = this.TablePrefix;
            context.Targets = this.Target;
            
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
            var request = new Amazon.Glue.Model.UpdateCrawlerRequest();
            
            if (cmdletContext.Classifiers != null)
            {
                request.Classifiers = cmdletContext.Classifiers;
            }
            if (cmdletContext.Configuration != null)
            {
                request.Configuration = cmdletContext.Configuration;
            }
            if (cmdletContext.CrawlerSecurityConfiguration != null)
            {
                request.CrawlerSecurityConfiguration = cmdletContext.CrawlerSecurityConfiguration;
            }
            if (cmdletContext.DatabaseName != null)
            {
                request.DatabaseName = cmdletContext.DatabaseName;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Role != null)
            {
                request.Role = cmdletContext.Role;
            }
            if (cmdletContext.Schedule != null)
            {
                request.Schedule = cmdletContext.Schedule;
            }
            if (cmdletContext.SchemaChangePolicy != null)
            {
                request.SchemaChangePolicy = cmdletContext.SchemaChangePolicy;
            }
            if (cmdletContext.TablePrefix != null)
            {
                request.TablePrefix = cmdletContext.TablePrefix;
            }
            if (cmdletContext.Targets != null)
            {
                request.Targets = cmdletContext.Targets;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.Name;
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
        
        private Amazon.Glue.Model.UpdateCrawlerResponse CallAWSServiceOperation(IAmazonGlue client, Amazon.Glue.Model.UpdateCrawlerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Glue", "UpdateCrawler");
            try
            {
                #if DESKTOP
                return client.UpdateCrawler(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateCrawlerAsync(request);
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
            public List<System.String> Classifiers { get; set; }
            public System.String Configuration { get; set; }
            public System.String CrawlerSecurityConfiguration { get; set; }
            public System.String DatabaseName { get; set; }
            public System.String Description { get; set; }
            public System.String Name { get; set; }
            public System.String Role { get; set; }
            public System.String Schedule { get; set; }
            public Amazon.Glue.Model.SchemaChangePolicy SchemaChangePolicy { get; set; }
            public System.String TablePrefix { get; set; }
            public Amazon.Glue.Model.CrawlerTargets Targets { get; set; }
        }
        
    }
}
