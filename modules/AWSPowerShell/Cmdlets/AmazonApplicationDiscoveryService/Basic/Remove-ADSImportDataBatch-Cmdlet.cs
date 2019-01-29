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
    /// Deletes one or more import tasks, each identified by their import ID. Each import
    /// task has a number of records that can identify servers or applications. 
    /// 
    ///  
    /// <para>
    /// AWS Application Discovery Service has built-in matching logic that will identify when
    /// discovered servers match existing entries that you've previously discovered, the information
    /// for the already-existing discovered server is updated. When you delete an import task
    /// that contains records that were used to match, the information in those matched records
    /// that comes from the deleted records will also be deleted.
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "ADSImportDataBatch", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.ApplicationDiscoveryService.Model.BatchDeleteImportDataError")]
    [AWSCmdlet("Calls the Application Discovery Service BatchDeleteImportData API operation.", Operation = new[] {"BatchDeleteImportData"})]
    [AWSCmdletOutput("Amazon.ApplicationDiscoveryService.Model.BatchDeleteImportDataError",
        "This cmdlet returns a collection of BatchDeleteImportDataError objects.",
        "The service call response (type Amazon.ApplicationDiscoveryService.Model.BatchDeleteImportDataResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RemoveADSImportDataBatchCmdlet : AmazonApplicationDiscoveryServiceClientCmdlet, IExecutor
    {
        
        #region Parameter ImportTaskId
        /// <summary>
        /// <para>
        /// <para>The IDs for the import tasks that you want to delete.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        [Alias("ImportTaskIds")]
        public System.String[] ImportTaskId { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ImportTaskId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-ADSImportDataBatch (BatchDeleteImportData)"))
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
            
            if (this.ImportTaskId != null)
            {
                context.ImportTaskIds = new List<System.String>(this.ImportTaskId);
            }
            
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
            var request = new Amazon.ApplicationDiscoveryService.Model.BatchDeleteImportDataRequest();
            
            if (cmdletContext.ImportTaskIds != null)
            {
                request.ImportTaskIds = cmdletContext.ImportTaskIds;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Errors;
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
        
        private Amazon.ApplicationDiscoveryService.Model.BatchDeleteImportDataResponse CallAWSServiceOperation(IAmazonApplicationDiscoveryService client, Amazon.ApplicationDiscoveryService.Model.BatchDeleteImportDataRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Application Discovery Service", "BatchDeleteImportData");
            try
            {
                #if DESKTOP
                return client.BatchDeleteImportData(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.BatchDeleteImportDataAsync(request);
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
            public List<System.String> ImportTaskIds { get; set; }
        }
        
    }
}
