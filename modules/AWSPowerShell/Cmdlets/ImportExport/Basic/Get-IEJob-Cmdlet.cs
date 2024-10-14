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
    [AWSCmdlet("Calls the AWS Import/Export ListJobs API operation.", Operation = new[] {"ListJobs"}, SelectReturnType = typeof(Amazon.ImportExport.Model.ListJobsResponse))]
    [AWSCmdletOutput("Amazon.ImportExport.Model.Job or Amazon.ImportExport.Model.ListJobsResponse",
        "This cmdlet returns a collection of Amazon.ImportExport.Model.Job objects.",
        "The service call response (type Amazon.ImportExport.Model.ListJobsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetIEJobCmdlet : AmazonImportExportClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter APIVersion
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String APIVersion { get; set; }
        #endregion
        
        #region Parameter MaxJob
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("MaxJobs")]
        public System.Int32? MaxJob { get; set; }
        #endregion
        
        #region Parameter Marker
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String Marker { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Jobs'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ImportExport.Model.ListJobsResponse).
        /// Specifying the name of a property of type Amazon.ImportExport.Model.ListJobsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Jobs";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the MaxJob parameter.
        /// The -PassThru parameter is deprecated, use -Select '^MaxJob' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^MaxJob' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v2";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ImportExport.Model.ListJobsResponse, GetIEJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.MaxJob;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.APIVersion = this.APIVersion;
            context.Marker = this.Marker;
            context.MaxJob = this.MaxJob;
            
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
            if (cmdletContext.MaxJob != null)
            {
                request.MaxJobs = cmdletContext.MaxJob.Value;
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
        
        private Amazon.ImportExport.Model.ListJobsResponse CallAWSServiceOperation(IAmazonImportExport client, Amazon.ImportExport.Model.ListJobsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Import/Export", "ListJobs");
            try
            {
                #if DESKTOP
                return client.ListJobs(request);
                #elif CORECLR
                return client.ListJobsAsync(request).GetAwaiter().GetResult();
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
            public System.String APIVersion { get; set; }
            public System.String Marker { get; set; }
            public System.Int32? MaxJob { get; set; }
            public System.Func<Amazon.ImportExport.Model.ListJobsResponse, GetIEJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Jobs;
        }
        
    }
}
