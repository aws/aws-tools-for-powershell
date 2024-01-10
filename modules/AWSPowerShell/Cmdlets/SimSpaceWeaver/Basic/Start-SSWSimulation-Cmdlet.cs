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
using Amazon.SimSpaceWeaver;
using Amazon.SimSpaceWeaver.Model;

namespace Amazon.PowerShell.Cmdlets.SSW
{
    /// <summary>
    /// Starts a simulation with the given name. You must choose to start your simulation
    /// from a schema or from a snapshot. For more information about the schema, see the <a href="https://docs.aws.amazon.com/simspaceweaver/latest/userguide/schema-reference.html">schema
    /// reference</a> in the <i>SimSpace Weaver User Guide</i>. For more information about
    /// snapshots, see <a href="https://docs.aws.amazon.com/simspaceweaver/latest/userguide/working-with_snapshots.html">Snapshots</a>
    /// in the <i>SimSpace Weaver User Guide</i>.
    /// </summary>
    [Cmdlet("Start", "SSWSimulation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SimSpaceWeaver.Model.StartSimulationResponse")]
    [AWSCmdlet("Calls the AWS SimSpace Weaver StartSimulation API operation.", Operation = new[] {"StartSimulation"}, SelectReturnType = typeof(Amazon.SimSpaceWeaver.Model.StartSimulationResponse))]
    [AWSCmdletOutput("Amazon.SimSpaceWeaver.Model.StartSimulationResponse",
        "This cmdlet returns an Amazon.SimSpaceWeaver.Model.StartSimulationResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartSSWSimulationCmdlet : AmazonSimSpaceWeaverClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter SchemaS3Location_BucketName
        /// <summary>
        /// <para>
        /// <para>The name of an Amazon S3 bucket. For more information about buckets, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/creating-buckets-s3.html">Creating,
        /// configuring, and working with Amazon S3 buckets</a> in the <i>Amazon Simple Storage
        /// Service User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SchemaS3Location_BucketName { get; set; }
        #endregion
        
        #region Parameter SnapshotS3Location_BucketName
        /// <summary>
        /// <para>
        /// <para>The name of an Amazon S3 bucket. For more information about buckets, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/creating-buckets-s3.html">Creating,
        /// configuring, and working with Amazon S3 buckets</a> in the <i>Amazon Simple Storage
        /// Service User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SnapshotS3Location_BucketName { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the simulation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter MaximumDuration
        /// <summary>
        /// <para>
        /// <para>The maximum running time of the simulation, specified as a number of minutes (m or
        /// M), hours (h or H), or days (d or D). The simulation stops when it reaches this limit.
        /// The maximum value is <c>14D</c>, or its equivalent in the other units. The default
        /// value is <c>14D</c>. A value equivalent to <c>0</c> makes the simulation immediately
        /// transition to <c>Stopping</c> as soon as it reaches <c>Started</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MaximumDuration { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the simulation.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter SchemaS3Location_ObjectKey
        /// <summary>
        /// <para>
        /// <para>The key name of an object in Amazon S3. For more information about Amazon S3 objects
        /// and object keys, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/uploading-downloading-objects.html">Uploading,
        /// downloading, and working with objects in Amazon S3</a> in the <i>Amazon Simple Storage
        /// Service User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SchemaS3Location_ObjectKey { get; set; }
        #endregion
        
        #region Parameter SnapshotS3Location_ObjectKey
        /// <summary>
        /// <para>
        /// <para>The key name of an object in Amazon S3. For more information about Amazon S3 objects
        /// and object keys, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/uploading-downloading-objects.html">Uploading,
        /// downloading, and working with objects in Amazon S3</a> in the <i>Amazon Simple Storage
        /// Service User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SnapshotS3Location_ObjectKey { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Identity and Access Management (IAM) role that
        /// the simulation assumes to perform actions. For more information about ARNs, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">Amazon
        /// Resource Names (ARNs)</a> in the <i>Amazon Web Services General Reference</i>. For
        /// more information about IAM roles, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/id_roles.html">IAM
        /// roles</a> in the <i>Identity and Access Management User Guide</i>.</para>
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
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of tags for the simulation. For more information about tags, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws_tagging.html">Tagging
        /// Amazon Web Services resources</a> in the <i>Amazon Web Services General Reference</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A value that you provide to ensure that repeated calls to this API operation using
        /// the same parameters complete only once. A <c>ClientToken</c> is also known as an <i>idempotency
        /// token</i>. A <c>ClientToken</c> expires after 24 hours.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimSpaceWeaver.Model.StartSimulationResponse).
        /// Specifying the name of a property of type Amazon.SimSpaceWeaver.Model.StartSimulationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-SSWSimulation (StartSimulation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimSpaceWeaver.Model.StartSimulationResponse, StartSSWSimulationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.MaximumDuration = this.MaximumDuration;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RoleArn = this.RoleArn;
            #if MODULAR
            if (this.RoleArn == null && ParameterWasBound(nameof(this.RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SchemaS3Location_BucketName = this.SchemaS3Location_BucketName;
            context.SchemaS3Location_ObjectKey = this.SchemaS3Location_ObjectKey;
            context.SnapshotS3Location_BucketName = this.SnapshotS3Location_BucketName;
            context.SnapshotS3Location_ObjectKey = this.SnapshotS3Location_ObjectKey;
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
            var request = new Amazon.SimSpaceWeaver.Model.StartSimulationRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.MaximumDuration != null)
            {
                request.MaximumDuration = cmdletContext.MaximumDuration;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            
             // populate SchemaS3Location
            var requestSchemaS3LocationIsNull = true;
            request.SchemaS3Location = new Amazon.SimSpaceWeaver.Model.S3Location();
            System.String requestSchemaS3Location_schemaS3Location_BucketName = null;
            if (cmdletContext.SchemaS3Location_BucketName != null)
            {
                requestSchemaS3Location_schemaS3Location_BucketName = cmdletContext.SchemaS3Location_BucketName;
            }
            if (requestSchemaS3Location_schemaS3Location_BucketName != null)
            {
                request.SchemaS3Location.BucketName = requestSchemaS3Location_schemaS3Location_BucketName;
                requestSchemaS3LocationIsNull = false;
            }
            System.String requestSchemaS3Location_schemaS3Location_ObjectKey = null;
            if (cmdletContext.SchemaS3Location_ObjectKey != null)
            {
                requestSchemaS3Location_schemaS3Location_ObjectKey = cmdletContext.SchemaS3Location_ObjectKey;
            }
            if (requestSchemaS3Location_schemaS3Location_ObjectKey != null)
            {
                request.SchemaS3Location.ObjectKey = requestSchemaS3Location_schemaS3Location_ObjectKey;
                requestSchemaS3LocationIsNull = false;
            }
             // determine if request.SchemaS3Location should be set to null
            if (requestSchemaS3LocationIsNull)
            {
                request.SchemaS3Location = null;
            }
            
             // populate SnapshotS3Location
            var requestSnapshotS3LocationIsNull = true;
            request.SnapshotS3Location = new Amazon.SimSpaceWeaver.Model.S3Location();
            System.String requestSnapshotS3Location_snapshotS3Location_BucketName = null;
            if (cmdletContext.SnapshotS3Location_BucketName != null)
            {
                requestSnapshotS3Location_snapshotS3Location_BucketName = cmdletContext.SnapshotS3Location_BucketName;
            }
            if (requestSnapshotS3Location_snapshotS3Location_BucketName != null)
            {
                request.SnapshotS3Location.BucketName = requestSnapshotS3Location_snapshotS3Location_BucketName;
                requestSnapshotS3LocationIsNull = false;
            }
            System.String requestSnapshotS3Location_snapshotS3Location_ObjectKey = null;
            if (cmdletContext.SnapshotS3Location_ObjectKey != null)
            {
                requestSnapshotS3Location_snapshotS3Location_ObjectKey = cmdletContext.SnapshotS3Location_ObjectKey;
            }
            if (requestSnapshotS3Location_snapshotS3Location_ObjectKey != null)
            {
                request.SnapshotS3Location.ObjectKey = requestSnapshotS3Location_snapshotS3Location_ObjectKey;
                requestSnapshotS3LocationIsNull = false;
            }
             // determine if request.SnapshotS3Location should be set to null
            if (requestSnapshotS3LocationIsNull)
            {
                request.SnapshotS3Location = null;
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
        
        private Amazon.SimSpaceWeaver.Model.StartSimulationResponse CallAWSServiceOperation(IAmazonSimSpaceWeaver client, Amazon.SimSpaceWeaver.Model.StartSimulationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS SimSpace Weaver", "StartSimulation");
            try
            {
                #if DESKTOP
                return client.StartSimulation(request);
                #elif CORECLR
                return client.StartSimulationAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public System.String MaximumDuration { get; set; }
            public System.String Name { get; set; }
            public System.String RoleArn { get; set; }
            public System.String SchemaS3Location_BucketName { get; set; }
            public System.String SchemaS3Location_ObjectKey { get; set; }
            public System.String SnapshotS3Location_BucketName { get; set; }
            public System.String SnapshotS3Location_ObjectKey { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.SimSpaceWeaver.Model.StartSimulationResponse, StartSSWSimulationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
