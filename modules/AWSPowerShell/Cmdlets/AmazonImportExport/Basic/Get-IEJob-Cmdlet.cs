/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.ImportExport;
using Amazon.ImportExport.Model;

namespace Amazon.PowerShell.Cmdlets.IE
{
    /// <summary>
    /// This operation returns the jobs associated with the requester. AWS Import/Export lists
    /// the jobs in reverse chronological order based on the date of creation. For example
    /// if Job Test1 was created 2009Dec30 and Test2 was created 2010Feb05, the ListJobs operation
    /// would return Test2 followed by Test1.
    /// </summary>
    [Cmdlet("Get", "IEJob")]
    [OutputType("Amazon.ImportExport.Model.Job")]
    [AWSCmdlet("Invokes the ListJobs operation against AWS Import/Export.", Operation = new[] {"ListJobs"})]
    [AWSCmdletOutput("Amazon.ImportExport.Model.Job",
        "This cmdlet returns a collection of Job objects.",
        "The service call response (type Amazon.ImportExport.Model.ListJobsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: IsTruncated (type System.Boolean)"
    )]
    public partial class GetIEJobCmdlet : AmazonImportExportClientCmdlet, IExecutor
    {
        
        #region Parameter APIVersion
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String APIVersion { get; set; }
        #endregion
        
        #region Parameter MaxJob
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        [Alias("MaxJobs")]
        public System.Int32 MaxJob { get; set; }
        #endregion
        
        #region Parameter Marker
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.String Marker { get; set; }
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
            
            context.APIVersion = this.APIVersion;
            context.Marker = this.Marker;
            if (ParameterWasBound("MaxJob"))
                context.MaxJobs = this.MaxJob;
            
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
            var request = new Amazon.ImportExport.Model.ListJobsRequest();
            
            if (cmdletContext.APIVersion != null)
            {
                request.APIVersion = cmdletContext.APIVersion;
            }
            if (cmdletContext.Marker != null)
            {
                request.Marker = cmdletContext.Marker;
            }
            if (cmdletContext.MaxJobs != null)
            {
                request.MaxJobs = cmdletContext.MaxJobs.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Jobs;
                notes = new Dictionary<string, object>();
                notes["IsTruncated"] = response.IsTruncated;
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
        
        private static Amazon.ImportExport.Model.ListJobsResponse CallAWSServiceOperation(IAmazonImportExport client, Amazon.ImportExport.Model.ListJobsRequest request)
        {
            #if DESKTOP
            return client.ListJobs(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.ListJobsAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String APIVersion { get; set; }
            public System.String Marker { get; set; }
            public System.Int32? MaxJobs { get; set; }
        }
        
    }
}
