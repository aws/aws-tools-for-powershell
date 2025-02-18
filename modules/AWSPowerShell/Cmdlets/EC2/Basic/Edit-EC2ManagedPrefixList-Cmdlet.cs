/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Threading;
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Modifies the specified managed prefix list.
    /// 
    ///  
    /// <para>
    /// Adding or removing entries in a prefix list creates a new version of the prefix list.
    /// Changing the name of the prefix list does not affect the version.
    /// </para><para>
    /// If you specify a current version number that does not match the true current version
    /// number, the request fails.
    /// </para>
    /// </summary>
    [Cmdlet("Edit", "EC2ManagedPrefixList", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.ManagedPrefixList")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) ModifyManagedPrefixList API operation.", Operation = new[] {"ModifyManagedPrefixList"}, SelectReturnType = typeof(Amazon.EC2.Model.ModifyManagedPrefixListResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.ManagedPrefixList or Amazon.EC2.Model.ModifyManagedPrefixListResponse",
        "This cmdlet returns an Amazon.EC2.Model.ManagedPrefixList object.",
        "The service call response (type Amazon.EC2.Model.ModifyManagedPrefixListResponse) can be returned by specifying '-Select *'."
    )]
    public partial class EditEC2ManagedPrefixListCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AddEntry
        /// <summary>
        /// <para>
        /// <para>One or more entries to add to the prefix list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AddEntries")]
        public Amazon.EC2.Model.AddPrefixListEntry[] AddEntry { get; set; }
        #endregion
        
        #region Parameter CurrentVersion
        /// <summary>
        /// <para>
        /// <para>The current version of the prefix list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? CurrentVersion { get; set; }
        #endregion
        
        #region Parameter MaxEntry
        /// <summary>
        /// <para>
        /// <para>The maximum number of entries for the prefix list. You cannot modify the entries of
        /// a prefix list and modify the size of a prefix list at the same time.</para><para>If any of the resources that reference the prefix list cannot support the new maximum
        /// size, the modify operation fails. Check the state message for the IDs of the first
        /// ten resources that do not support the new maximum size.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxEntries")]
        public System.Int32? MaxEntry { get; set; }
        #endregion
        
        #region Parameter PrefixListId
        /// <summary>
        /// <para>
        /// <para>The ID of the prefix list.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String PrefixListId { get; set; }
        #endregion
        
        #region Parameter PrefixListName
        /// <summary>
        /// <para>
        /// <para>A name for the prefix list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PrefixListName { get; set; }
        #endregion
        
        #region Parameter RemoveEntry
        /// <summary>
        /// <para>
        /// <para>One or more entries to remove from the prefix list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RemoveEntries")]
        public Amazon.EC2.Model.RemovePrefixListEntry[] RemoveEntry { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'PrefixList'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.ModifyManagedPrefixListResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.ModifyManagedPrefixListResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "PrefixList";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PrefixListId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EC2ManagedPrefixList (ModifyManagedPrefixList)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.ModifyManagedPrefixListResponse, EditEC2ManagedPrefixListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AddEntry != null)
            {
                context.AddEntry = new List<Amazon.EC2.Model.AddPrefixListEntry>(this.AddEntry);
            }
            context.CurrentVersion = this.CurrentVersion;
            context.MaxEntry = this.MaxEntry;
            context.PrefixListId = this.PrefixListId;
            #if MODULAR
            if (this.PrefixListId == null && ParameterWasBound(nameof(this.PrefixListId)))
            {
                WriteWarning("You are passing $null as a value for parameter PrefixListId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PrefixListName = this.PrefixListName;
            if (this.RemoveEntry != null)
            {
                context.RemoveEntry = new List<Amazon.EC2.Model.RemovePrefixListEntry>(this.RemoveEntry);
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
            var request = new Amazon.EC2.Model.ModifyManagedPrefixListRequest();
            
            if (cmdletContext.AddEntry != null)
            {
                request.AddEntries = cmdletContext.AddEntry;
            }
            if (cmdletContext.CurrentVersion != null)
            {
                request.CurrentVersion = cmdletContext.CurrentVersion.Value;
            }
            if (cmdletContext.MaxEntry != null)
            {
                request.MaxEntries = cmdletContext.MaxEntry.Value;
            }
            if (cmdletContext.PrefixListId != null)
            {
                request.PrefixListId = cmdletContext.PrefixListId;
            }
            if (cmdletContext.PrefixListName != null)
            {
                request.PrefixListName = cmdletContext.PrefixListName;
            }
            if (cmdletContext.RemoveEntry != null)
            {
                request.RemoveEntries = cmdletContext.RemoveEntry;
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
        
        private Amazon.EC2.Model.ModifyManagedPrefixListResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ModifyManagedPrefixListRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "ModifyManagedPrefixList");
            try
            {
                return client.ModifyManagedPrefixListAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.EC2.Model.AddPrefixListEntry> AddEntry { get; set; }
            public System.Int64? CurrentVersion { get; set; }
            public System.Int32? MaxEntry { get; set; }
            public System.String PrefixListId { get; set; }
            public System.String PrefixListName { get; set; }
            public List<Amazon.EC2.Model.RemovePrefixListEntry> RemoveEntry { get; set; }
            public System.Func<Amazon.EC2.Model.ModifyManagedPrefixListResponse, EditEC2ManagedPrefixListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.PrefixList;
        }
        
    }
}
