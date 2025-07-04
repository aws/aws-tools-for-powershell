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
using Amazon.Finspace;
using Amazon.Finspace.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.FINSP
{
    /// <summary>
    /// Creates a snapshot of kdb database with tiered storage capabilities and a pre-warmed
    /// cache, ready for mounting on kdb clusters. Dataviews are only available for clusters
    /// running on a scaling group. They are not supported on dedicated clusters.
    /// </summary>
    [Cmdlet("New", "FINSPKxDataview", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Finspace.Model.CreateKxDataviewResponse")]
    [AWSCmdlet("Calls the FinSpace User Environment Management Service CreateKxDataview API operation.", Operation = new[] {"CreateKxDataview"}, SelectReturnType = typeof(Amazon.Finspace.Model.CreateKxDataviewResponse))]
    [AWSCmdletOutput("Amazon.Finspace.Model.CreateKxDataviewResponse",
        "This cmdlet returns an Amazon.Finspace.Model.CreateKxDataviewResponse object containing multiple properties."
    )]
    public partial class NewFINSPKxDataviewCmdlet : AmazonFinspaceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AutoUpdate
        /// <summary>
        /// <para>
        /// <para>The option to specify whether you want to apply all the future additions and corrections
        /// automatically to the dataview, when you ingest new changesets. The default value is
        /// false.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AutoUpdate { get; set; }
        #endregion
        
        #region Parameter AvailabilityZoneId
        /// <summary>
        /// <para>
        /// <para> The identifier of the availability zones. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AvailabilityZoneId { get; set; }
        #endregion
        
        #region Parameter AzMode
        /// <summary>
        /// <para>
        /// <para>The number of availability zones you want to assign per volume. Currently, FinSpace
        /// only supports <c>SINGLE</c> for volumes. This places dataview in a single AZ.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Finspace.KxAzMode")]
        public Amazon.Finspace.KxAzMode AzMode { get; set; }
        #endregion
        
        #region Parameter ChangesetId
        /// <summary>
        /// <para>
        /// <para> A unique identifier of the changeset that you want to use to ingest data. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ChangesetId { get; set; }
        #endregion
        
        #region Parameter DatabaseName
        /// <summary>
        /// <para>
        /// <para> The name of the database where you want to create a dataview. </para>
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
        public System.String DatabaseName { get; set; }
        #endregion
        
        #region Parameter DataviewName
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the dataview.</para>
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
        public System.String DataviewName { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the dataview.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter EnvironmentId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the kdb environment, where you want to create the dataview.
        /// </para>
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
        public System.String EnvironmentId { get; set; }
        #endregion
        
        #region Parameter ReadWrite
        /// <summary>
        /// <para>
        /// <para> The option to specify whether you want to make the dataview writable to perform database
        /// maintenance. The following are some considerations related to writable dataviews.  </para><ul><li><para>You cannot create partial writable dataviews. When you create writeable dataviews
        /// you must provide the entire database path.</para></li><li><para>You cannot perform updates on a writeable dataview. Hence, <c>autoUpdate</c> must
        /// be set as <b>False</b> if <c>readWrite</c> is <b>True</b> for a dataview.</para></li><li><para>You must also use a unique volume for creating a writeable dataview. So, if you choose
        /// a volume that is already in use by another dataview, the dataview creation fails.</para></li><li><para>Once you create a dataview as writeable, you cannot change it to read-only. So, you
        /// cannot update the <c>readWrite</c> parameter later.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ReadWrite { get; set; }
        #endregion
        
        #region Parameter SegmentConfiguration
        /// <summary>
        /// <para>
        /// <para> The configuration that contains the database path of the data that you want to place
        /// on each selected volume. Each segment must have a unique database path for each volume.
        /// If you do not explicitly specify any database path for a volume, they are accessible
        /// from the cluster through the default S3/object store segment. </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SegmentConfigurations")]
        public Amazon.Finspace.Model.KxDataviewSegmentConfiguration[] SegmentConfiguration { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para> A list of key-value pairs to label the dataview. You can add up to 50 tags to a dataview.
        /// </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A token that ensures idempotency. This token expires in 10 minutes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Finspace.Model.CreateKxDataviewResponse).
        /// Specifying the name of a property of type Amazon.Finspace.Model.CreateKxDataviewResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DataviewName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-FINSPKxDataview (CreateKxDataview)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Finspace.Model.CreateKxDataviewResponse, NewFINSPKxDataviewCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AutoUpdate = this.AutoUpdate;
            context.AvailabilityZoneId = this.AvailabilityZoneId;
            context.AzMode = this.AzMode;
            #if MODULAR
            if (this.AzMode == null && ParameterWasBound(nameof(this.AzMode)))
            {
                WriteWarning("You are passing $null as a value for parameter AzMode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ChangesetId = this.ChangesetId;
            context.ClientToken = this.ClientToken;
            context.DatabaseName = this.DatabaseName;
            #if MODULAR
            if (this.DatabaseName == null && ParameterWasBound(nameof(this.DatabaseName)))
            {
                WriteWarning("You are passing $null as a value for parameter DatabaseName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DataviewName = this.DataviewName;
            #if MODULAR
            if (this.DataviewName == null && ParameterWasBound(nameof(this.DataviewName)))
            {
                WriteWarning("You are passing $null as a value for parameter DataviewName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            context.EnvironmentId = this.EnvironmentId;
            #if MODULAR
            if (this.EnvironmentId == null && ParameterWasBound(nameof(this.EnvironmentId)))
            {
                WriteWarning("You are passing $null as a value for parameter EnvironmentId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ReadWrite = this.ReadWrite;
            if (this.SegmentConfiguration != null)
            {
                context.SegmentConfiguration = new List<Amazon.Finspace.Model.KxDataviewSegmentConfiguration>(this.SegmentConfiguration);
            }
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
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
            var request = new Amazon.Finspace.Model.CreateKxDataviewRequest();
            
            if (cmdletContext.AutoUpdate != null)
            {
                request.AutoUpdate = cmdletContext.AutoUpdate.Value;
            }
            if (cmdletContext.AvailabilityZoneId != null)
            {
                request.AvailabilityZoneId = cmdletContext.AvailabilityZoneId;
            }
            if (cmdletContext.AzMode != null)
            {
                request.AzMode = cmdletContext.AzMode;
            }
            if (cmdletContext.ChangesetId != null)
            {
                request.ChangesetId = cmdletContext.ChangesetId;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DatabaseName != null)
            {
                request.DatabaseName = cmdletContext.DatabaseName;
            }
            if (cmdletContext.DataviewName != null)
            {
                request.DataviewName = cmdletContext.DataviewName;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.EnvironmentId != null)
            {
                request.EnvironmentId = cmdletContext.EnvironmentId;
            }
            if (cmdletContext.ReadWrite != null)
            {
                request.ReadWrite = cmdletContext.ReadWrite.Value;
            }
            if (cmdletContext.SegmentConfiguration != null)
            {
                request.SegmentConfigurations = cmdletContext.SegmentConfiguration;
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
        
        private Amazon.Finspace.Model.CreateKxDataviewResponse CallAWSServiceOperation(IAmazonFinspace client, Amazon.Finspace.Model.CreateKxDataviewRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "FinSpace User Environment Management Service", "CreateKxDataview");
            try
            {
                return client.CreateKxDataviewAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? AutoUpdate { get; set; }
            public System.String AvailabilityZoneId { get; set; }
            public Amazon.Finspace.KxAzMode AzMode { get; set; }
            public System.String ChangesetId { get; set; }
            public System.String ClientToken { get; set; }
            public System.String DatabaseName { get; set; }
            public System.String DataviewName { get; set; }
            public System.String Description { get; set; }
            public System.String EnvironmentId { get; set; }
            public System.Boolean? ReadWrite { get; set; }
            public List<Amazon.Finspace.Model.KxDataviewSegmentConfiguration> SegmentConfiguration { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.Finspace.Model.CreateKxDataviewResponse, NewFINSPKxDataviewCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
