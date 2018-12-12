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
using Amazon.CognitoSync;
using Amazon.CognitoSync.Model;

namespace Amazon.PowerShell.Cmdlets.CGIS
{
    /// <summary>
    /// Deletes the specific dataset. The dataset will be deleted permanently, and the action
    /// can't be undone. Datasets that this dataset was merged with will no longer report
    /// the merge. Any subsequent operation on this dataset will result in a ResourceNotFoundException.
    /// 
    ///  
    /// <para>
    /// This API can be called with temporary user credentials provided by Cognito Identity
    /// or with developer credentials.
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "CGISDataset", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.CognitoSync.Model.Dataset")]
    [AWSCmdlet("Calls the Amazon Cognito Sync DeleteDataset API operation.", Operation = new[] {"DeleteDataset"})]
    [AWSCmdletOutput("Amazon.CognitoSync.Model.Dataset",
        "This cmdlet returns a Dataset object.",
        "The service call response (type Amazon.CognitoSync.Model.DeleteDatasetResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RemoveCGISDatasetCmdlet : AmazonCognitoSyncClientCmdlet, IExecutor
    {
        
        #region Parameter DatasetName
        /// <summary>
        /// <para>
        /// A string of up to 128 characters. Allowed
        /// characters are a-z, A-Z, 0-9, '_' (underscore), '-' (dash), and '.' (dot).
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String DatasetName { get; set; }
        #endregion
        
        #region Parameter IdentityId
        /// <summary>
        /// <para>
        /// A name-spaced GUID (for example, us-east-1:23EC4050-6AEA-7089-A2DD-08002EXAMPLE)
        /// created by Amazon Cognito. GUID generation is unique within a region.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdentityId { get; set; }
        #endregion
        
        #region Parameter IdentityPoolId
        /// <summary>
        /// <para>
        /// A name-spaced GUID (for example, us-east-1:23EC4050-6AEA-7089-A2DD-08002EXAMPLE)
        /// created by Amazon Cognito. GUID generation is unique within a region.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdentityPoolId { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("DatasetName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-CGISDataset (DeleteDataset)"))
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
            
            context.DatasetName = this.DatasetName;
            context.IdentityId = this.IdentityId;
            context.IdentityPoolId = this.IdentityPoolId;
            
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
            var request = new Amazon.CognitoSync.Model.DeleteDatasetRequest();
            
            if (cmdletContext.DatasetName != null)
            {
                request.DatasetName = cmdletContext.DatasetName;
            }
            if (cmdletContext.IdentityId != null)
            {
                request.IdentityId = cmdletContext.IdentityId;
            }
            if (cmdletContext.IdentityPoolId != null)
            {
                request.IdentityPoolId = cmdletContext.IdentityPoolId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Dataset;
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
        
        private Amazon.CognitoSync.Model.DeleteDatasetResponse CallAWSServiceOperation(IAmazonCognitoSync client, Amazon.CognitoSync.Model.DeleteDatasetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Cognito Sync", "DeleteDataset");
            try
            {
                #if DESKTOP
                return client.DeleteDataset(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DeleteDatasetAsync(request);
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
            public System.String DatasetName { get; set; }
            public System.String IdentityId { get; set; }
            public System.String IdentityPoolId { get; set; }
        }
        
    }
}
