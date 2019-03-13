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
using Amazon.SecurityHub;
using Amazon.SecurityHub.Model;

namespace Amazon.PowerShell.Cmdlets.SHUB
{
    /// <summary>
    /// Updates the AWS Security Hub-aggregated findings specified by the filter attributes.
    /// </summary>
    [Cmdlet("Update", "SHUBFinding", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Security Hub UpdateFindings API operation.", Operation = new[] {"UpdateFindings"})]
    [AWSCmdletOutput("None",
        "This cmdlet does not generate any output. " +
        "The service response (type Amazon.SecurityHub.Model.UpdateFindingsResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateSHUBFindingCmdlet : AmazonSecurityHubClientCmdlet, IExecutor
    {
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>A collection of attributes that specify what findings you want to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Filters")]
        public Amazon.SecurityHub.Model.AwsSecurityFindingFilters Filter { get; set; }
        #endregion
        
        #region Parameter RecordState
        /// <summary>
        /// <para>
        /// <para>The updated record state for the finding.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.SecurityHub.RecordState")]
        public Amazon.SecurityHub.RecordState RecordState { get; set; }
        #endregion
        
        #region Parameter Note_Text
        /// <summary>
        /// <para>
        /// <para>The updated note text.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Note_Text { get; set; }
        #endregion
        
        #region Parameter Note_UpdatedBy
        /// <summary>
        /// <para>
        /// <para>The principal that updated the note.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Note_UpdatedBy { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SHUBFinding (UpdateFindings)"))
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
            
            context.Filters = this.Filter;
            context.Note_Text = this.Note_Text;
            context.Note_UpdatedBy = this.Note_UpdatedBy;
            context.RecordState = this.RecordState;
            
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
            var request = new Amazon.SecurityHub.Model.UpdateFindingsRequest();
            
            if (cmdletContext.Filters != null)
            {
                request.Filters = cmdletContext.Filters;
            }
            
             // populate Note
            bool requestNoteIsNull = true;
            request.Note = new Amazon.SecurityHub.Model.NoteUpdate();
            System.String requestNote_note_Text = null;
            if (cmdletContext.Note_Text != null)
            {
                requestNote_note_Text = cmdletContext.Note_Text;
            }
            if (requestNote_note_Text != null)
            {
                request.Note.Text = requestNote_note_Text;
                requestNoteIsNull = false;
            }
            System.String requestNote_note_UpdatedBy = null;
            if (cmdletContext.Note_UpdatedBy != null)
            {
                requestNote_note_UpdatedBy = cmdletContext.Note_UpdatedBy;
            }
            if (requestNote_note_UpdatedBy != null)
            {
                request.Note.UpdatedBy = requestNote_note_UpdatedBy;
                requestNoteIsNull = false;
            }
             // determine if request.Note should be set to null
            if (requestNoteIsNull)
            {
                request.Note = null;
            }
            if (cmdletContext.RecordState != null)
            {
                request.RecordState = cmdletContext.RecordState;
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
        
        private Amazon.SecurityHub.Model.UpdateFindingsResponse CallAWSServiceOperation(IAmazonSecurityHub client, Amazon.SecurityHub.Model.UpdateFindingsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Security Hub", "UpdateFindings");
            try
            {
                #if DESKTOP
                return client.UpdateFindings(request);
                #elif CORECLR
                return client.UpdateFindingsAsync(request).GetAwaiter().GetResult();
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
            public Amazon.SecurityHub.Model.AwsSecurityFindingFilters Filters { get; set; }
            public System.String Note_Text { get; set; }
            public System.String Note_UpdatedBy { get; set; }
            public Amazon.SecurityHub.RecordState RecordState { get; set; }
        }
        
    }
}
