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
    /// Gets code to perform a specified mapping.
    /// </summary>
    [Cmdlet("Get", "GLUEPlan")]
    [OutputType("Amazon.Glue.Model.GetPlanResponse")]
    [AWSCmdlet("Calls the AWS Glue GetPlan API operation.", Operation = new[] {"GetPlan"})]
    [AWSCmdletOutput("Amazon.Glue.Model.GetPlanResponse",
        "This cmdlet returns a Amazon.Glue.Model.GetPlanResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetGLUEPlanCmdlet : AmazonGlueClientCmdlet, IExecutor
    {
        
        #region Parameter Language
        /// <summary>
        /// <para>
        /// <para>The programming language of the code to perform the mapping.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Glue.Language")]
        public Amazon.Glue.Language Language { get; set; }
        #endregion
        
        #region Parameter Location
        /// <summary>
        /// <para>
        /// <para>Parameters for the mapping.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.Glue.Model.Location Location { get; set; }
        #endregion
        
        #region Parameter Mapping
        /// <summary>
        /// <para>
        /// <para>The list of mappings from a source table to target tables.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.Glue.Model.MappingEntry[] Mapping { get; set; }
        #endregion
        
        #region Parameter Sink
        /// <summary>
        /// <para>
        /// <para>The target tables.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Sinks")]
        public Amazon.Glue.Model.CatalogEntry[] Sink { get; set; }
        #endregion
        
        #region Parameter Source
        /// <summary>
        /// <para>
        /// <para>The source table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public Amazon.Glue.Model.CatalogEntry Source { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.Language = this.Language;
            context.Location = this.Location;
            if (this.Mapping != null)
            {
                context.Mapping = new List<Amazon.Glue.Model.MappingEntry>(this.Mapping);
            }
            if (this.Sink != null)
            {
                context.Sinks = new List<Amazon.Glue.Model.CatalogEntry>(this.Sink);
            }
            context.Source = this.Source;
            
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
            var request = new Amazon.Glue.Model.GetPlanRequest();
            
            if (cmdletContext.Language != null)
            {
                request.Language = cmdletContext.Language;
            }
            if (cmdletContext.Location != null)
            {
                request.Location = cmdletContext.Location;
            }
            if (cmdletContext.Mapping != null)
            {
                request.Mapping = cmdletContext.Mapping;
            }
            if (cmdletContext.Sinks != null)
            {
                request.Sinks = cmdletContext.Sinks;
            }
            if (cmdletContext.Source != null)
            {
                request.Source = cmdletContext.Source;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
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
        
        private Amazon.Glue.Model.GetPlanResponse CallAWSServiceOperation(IAmazonGlue client, Amazon.Glue.Model.GetPlanRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Glue", "GetPlan");
            try
            {
                #if DESKTOP
                return client.GetPlan(request);
                #elif CORECLR
                return client.GetPlanAsync(request).GetAwaiter().GetResult();
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
            public Amazon.Glue.Language Language { get; set; }
            public Amazon.Glue.Model.Location Location { get; set; }
            public List<Amazon.Glue.Model.MappingEntry> Mapping { get; set; }
            public List<Amazon.Glue.Model.CatalogEntry> Sinks { get; set; }
            public Amazon.Glue.Model.CatalogEntry Source { get; set; }
        }
        
    }
}
