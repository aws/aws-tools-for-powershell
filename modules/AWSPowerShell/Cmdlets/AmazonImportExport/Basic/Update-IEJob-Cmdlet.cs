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
    /// You use this operation to change the parameters specified in the original manifest
    /// file by supplying a new manifest file. The manifest file attached to this request
    /// replaces the original manifest file. You can only use the operation after a CreateJob
    /// request but before the data transfer starts and you can only use it on jobs you own.
    /// </summary>
    [Cmdlet("Update", "IEJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ImportExport.Model.UpdateJobResponse")]
    [AWSCmdlet("Invokes the UpdateJob operation against AWS Import/Export.", Operation = new[] {"UpdateJob"})]
    [AWSCmdletOutput("Amazon.ImportExport.Model.UpdateJobResponse",
        "This cmdlet returns a Amazon.ImportExport.Model.UpdateJobResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateIEJobCmdlet : AmazonImportExportClientCmdlet, IExecutor
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
        
        #region Parameter JobId
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String JobId { get; set; }
        #endregion
        
        #region Parameter JobType
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        [AWSConstantClassSource("Amazon.ImportExport.JobType")]
        public Amazon.ImportExport.JobType JobType { get; set; }
        #endregion
        
        #region Parameter Manifest
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.String Manifest { get; set; }
        #endregion
        
        #region Parameter ValidateOnly
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3)]
        public System.Boolean ValidateOnly { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("JobId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-IEJob (UpdateJob)"))
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
            
            context.APIVersion = this.APIVersion;
            context.JobId = this.JobId;
            context.JobType = this.JobType;
            context.Manifest = this.Manifest;
            if (ParameterWasBound("ValidateOnly"))
                context.ValidateOnly = this.ValidateOnly;
            
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
            var request = new Amazon.ImportExport.Model.UpdateJobRequest();
            
            if (cmdletContext.APIVersion != null)
            {
                request.APIVersion = cmdletContext.APIVersion;
            }
            if (cmdletContext.JobId != null)
            {
                request.JobId = cmdletContext.JobId;
            }
            if (cmdletContext.JobType != null)
            {
                request.JobType = cmdletContext.JobType;
            }
            if (cmdletContext.Manifest != null)
            {
                request.Manifest = cmdletContext.Manifest;
            }
            if (cmdletContext.ValidateOnly != null)
            {
                request.ValidateOnly = cmdletContext.ValidateOnly.Value;
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
        
        private static Amazon.ImportExport.Model.UpdateJobResponse CallAWSServiceOperation(IAmazonImportExport client, Amazon.ImportExport.Model.UpdateJobRequest request)
        {
            #if DESKTOP
            return client.UpdateJob(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.UpdateJobAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String APIVersion { get; set; }
            public System.String JobId { get; set; }
            public Amazon.ImportExport.JobType JobType { get; set; }
            public System.String Manifest { get; set; }
            public System.Boolean? ValidateOnly { get; set; }
        }
        
    }
}
