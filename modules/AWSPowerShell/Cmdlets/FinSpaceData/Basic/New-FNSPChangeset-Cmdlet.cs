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
using Amazon.FinSpaceData;
using Amazon.FinSpaceData.Model;

namespace Amazon.PowerShell.Cmdlets.FNSP
{
    /// <summary>
    /// Creates a new changeset in a FinSpace dataset.
    /// </summary>
    [Cmdlet("New", "FNSPChangeset", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.FinSpaceData.Model.ChangesetInfo")]
    [AWSCmdlet("Calls the FinSpace Public API CreateChangeset API operation.", Operation = new[] {"CreateChangeset"}, SelectReturnType = typeof(Amazon.FinSpaceData.Model.CreateChangesetResponse))]
    [AWSCmdletOutput("Amazon.FinSpaceData.Model.ChangesetInfo or Amazon.FinSpaceData.Model.CreateChangesetResponse",
        "This cmdlet returns an Amazon.FinSpaceData.Model.ChangesetInfo object.",
        "The service call response (type Amazon.FinSpaceData.Model.CreateChangesetResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewFNSPChangesetCmdlet : AmazonFinSpaceDataClientCmdlet, IExecutor
    {
        
        #region Parameter ChangeType
        /// <summary>
        /// <para>
        /// <para>Option to indicate how a changeset will be applied to a dataset.</para><ul><li><para><code>REPLACE</code> - Changeset will be considered as a replacement to all prior
        /// loaded changesets.</para></li><li><para><code>APPEND</code> - Changeset will be considered as an addition to the end of all
        /// prior loaded changesets.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.FinSpaceData.ChangeType")]
        public Amazon.FinSpaceData.ChangeType ChangeType { get; set; }
        #endregion
        
        #region Parameter DatasetId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the FinSpace dataset in which the changeset will be created.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String DatasetId { get; set; }
        #endregion
        
        #region Parameter FormatParam
        /// <summary>
        /// <para>
        /// <para>Options that define the structure of the source file(s).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FormatParams")]
        public System.Collections.Hashtable FormatParam { get; set; }
        #endregion
        
        #region Parameter FormatType
        /// <summary>
        /// <para>
        /// <para>Format type of the input files being loaded into the changeset.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.FinSpaceData.FormatType")]
        public Amazon.FinSpaceData.FormatType FormatType { get; set; }
        #endregion
        
        #region Parameter SourceParam
        /// <summary>
        /// <para>
        /// <para>Source path from which the files to create the changeset will be sourced.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("SourceParams")]
        public System.Collections.Hashtable SourceParam { get; set; }
        #endregion
        
        #region Parameter SourceType
        /// <summary>
        /// <para>
        /// <para>Type of the data source from which the files to create the changeset will be sourced.</para><ul><li><para><code>S3</code> - Amazon S3.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.FinSpaceData.SourceType")]
        public Amazon.FinSpaceData.SourceType SourceType { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Metadata tags to apply to this changeset.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Changeset'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.FinSpaceData.Model.CreateChangesetResponse).
        /// Specifying the name of a property of type Amazon.FinSpaceData.Model.CreateChangesetResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Changeset";
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
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DatasetId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-FNSPChangeset (CreateChangeset)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.FinSpaceData.Model.CreateChangesetResponse, NewFNSPChangesetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ChangeType = this.ChangeType;
            #if MODULAR
            if (this.ChangeType == null && ParameterWasBound(nameof(this.ChangeType)))
            {
                WriteWarning("You are passing $null as a value for parameter ChangeType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DatasetId = this.DatasetId;
            #if MODULAR
            if (this.DatasetId == null && ParameterWasBound(nameof(this.DatasetId)))
            {
                WriteWarning("You are passing $null as a value for parameter DatasetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.FormatParam != null)
            {
                context.FormatParam = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.FormatParam.Keys)
                {
                    context.FormatParam.Add((String)hashKey, (String)(this.FormatParam[hashKey]));
                }
            }
            context.FormatType = this.FormatType;
            if (this.SourceParam != null)
            {
                context.SourceParam = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.SourceParam.Keys)
                {
                    context.SourceParam.Add((String)hashKey, (String)(this.SourceParam[hashKey]));
                }
            }
            #if MODULAR
            if (this.SourceParam == null && ParameterWasBound(nameof(this.SourceParam)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceParam which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SourceType = this.SourceType;
            #if MODULAR
            if (this.SourceType == null && ParameterWasBound(nameof(this.SourceType)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (String)(this.Tag[hashKey]));
                }
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
            var request = new Amazon.FinSpaceData.Model.CreateChangesetRequest();
            
            if (cmdletContext.ChangeType != null)
            {
                request.ChangeType = cmdletContext.ChangeType;
            }
            if (cmdletContext.DatasetId != null)
            {
                request.DatasetId = cmdletContext.DatasetId;
            }
            if (cmdletContext.FormatParam != null)
            {
                request.FormatParams = cmdletContext.FormatParam;
            }
            if (cmdletContext.FormatType != null)
            {
                request.FormatType = cmdletContext.FormatType;
            }
            if (cmdletContext.SourceParam != null)
            {
                request.SourceParams = cmdletContext.SourceParam;
            }
            if (cmdletContext.SourceType != null)
            {
                request.SourceType = cmdletContext.SourceType;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.FinSpaceData.Model.CreateChangesetResponse CallAWSServiceOperation(IAmazonFinSpaceData client, Amazon.FinSpaceData.Model.CreateChangesetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "FinSpace Public API", "CreateChangeset");
            try
            {
                #if DESKTOP
                return client.CreateChangeset(request);
                #elif CORECLR
                return client.CreateChangesetAsync(request).GetAwaiter().GetResult();
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
            public Amazon.FinSpaceData.ChangeType ChangeType { get; set; }
            public System.String DatasetId { get; set; }
            public Dictionary<System.String, System.String> FormatParam { get; set; }
            public Amazon.FinSpaceData.FormatType FormatType { get; set; }
            public Dictionary<System.String, System.String> SourceParam { get; set; }
            public Amazon.FinSpaceData.SourceType SourceType { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.FinSpaceData.Model.CreateChangesetResponse, NewFNSPChangesetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Changeset;
        }
        
    }
}
