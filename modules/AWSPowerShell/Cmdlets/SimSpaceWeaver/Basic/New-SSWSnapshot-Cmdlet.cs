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
using Amazon.SimSpaceWeaver;
using Amazon.SimSpaceWeaver.Model;

namespace Amazon.PowerShell.Cmdlets.SSW
{
    /// <summary>
    /// Creates a snapshot of the specified simulation. A snapshot is a file that contains
    /// simulation state data at a specific time. The state data saved in a snapshot includes
    /// entity data from the State Fabric, the simulation configuration specified in the schema,
    /// and the clock tick number. You can use the snapshot to initialize a new simulation.
    /// For more information about snapshots, see <a href="https://docs.aws.amazon.com/simspaceweaver/latest/userguide/working-with_snapshots.html">Snapshots</a>
    /// in the <i>SimSpace Weaver User Guide</i>. 
    /// 
    ///  
    /// <para>
    /// You specify a <c>Destination</c> when you create a snapshot. The <c>Destination</c>
    /// is the name of an Amazon S3 bucket and an optional <c>ObjectKeyPrefix</c>. The <c>ObjectKeyPrefix</c>
    /// is usually the name of a folder in the bucket. SimSpace Weaver creates a <c>snapshot</c>
    /// folder inside the <c>Destination</c> and places the snapshot file there.
    /// </para><para>
    /// The snapshot file is an Amazon S3 object. It has an object key with the form: <c><i>object-key-prefix</i>/snapshot/<i>simulation-name</i>-<i>YYMMdd</i>-<i>HHmm</i>-<i>ss</i>.zip</c>,
    /// where: 
    /// </para><ul><li><para><c><i>YY</i></c> is the 2-digit year
    /// </para></li><li><para><c><i>MM</i></c> is the 2-digit month
    /// </para></li><li><para><c><i>dd</i></c> is the 2-digit day of the month
    /// </para></li><li><para><c><i>HH</i></c> is the 2-digit hour (24-hour clock)
    /// </para></li><li><para><c><i>mm</i></c> is the 2-digit minutes
    /// </para></li><li><para><c><i>ss</i></c> is the 2-digit seconds
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("New", "SSWSnapshot", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS SimSpace Weaver CreateSnapshot API operation.", Operation = new[] {"CreateSnapshot"}, SelectReturnType = typeof(Amazon.SimSpaceWeaver.Model.CreateSnapshotResponse))]
    [AWSCmdletOutput("None or Amazon.SimSpaceWeaver.Model.CreateSnapshotResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SimSpaceWeaver.Model.CreateSnapshotResponse) be returned by specifying '-Select *'."
    )]
    public partial class NewSSWSnapshotCmdlet : AmazonSimSpaceWeaverClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Destination_BucketName
        /// <summary>
        /// <para>
        /// <para>The name of an Amazon S3 bucket. For more information about buckets, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/creating-buckets-s3.html">Creating,
        /// configuring, and working with Amazon S3 buckets</a> in the <i>Amazon Simple Storage
        /// Service User Guide</i>.</para>
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
        public System.String Destination_BucketName { get; set; }
        #endregion
        
        #region Parameter Destination_ObjectKeyPrefix
        /// <summary>
        /// <para>
        /// <para>A string prefix for an Amazon S3 object key. It's usually a folder name. For more
        /// information about folders in Amazon S3, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/using-folders.html">Organizing
        /// objects in the Amazon S3 console using folders</a> in the <i>Amazon Simple Storage
        /// Service User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Destination_ObjectKeyPrefix { get; set; }
        #endregion
        
        #region Parameter Simulation
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
        public System.String Simulation { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimSpaceWeaver.Model.CreateSnapshotResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Simulation parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Simulation' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Simulation' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Destination_BucketName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SSWSnapshot (CreateSnapshot)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimSpaceWeaver.Model.CreateSnapshotResponse, NewSSWSnapshotCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Simulation;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Destination_BucketName = this.Destination_BucketName;
            #if MODULAR
            if (this.Destination_BucketName == null && ParameterWasBound(nameof(this.Destination_BucketName)))
            {
                WriteWarning("You are passing $null as a value for parameter Destination_BucketName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Destination_ObjectKeyPrefix = this.Destination_ObjectKeyPrefix;
            context.Simulation = this.Simulation;
            #if MODULAR
            if (this.Simulation == null && ParameterWasBound(nameof(this.Simulation)))
            {
                WriteWarning("You are passing $null as a value for parameter Simulation which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.SimSpaceWeaver.Model.CreateSnapshotRequest();
            
            
             // populate Destination
            var requestDestinationIsNull = true;
            request.Destination = new Amazon.SimSpaceWeaver.Model.S3Destination();
            System.String requestDestination_destination_BucketName = null;
            if (cmdletContext.Destination_BucketName != null)
            {
                requestDestination_destination_BucketName = cmdletContext.Destination_BucketName;
            }
            if (requestDestination_destination_BucketName != null)
            {
                request.Destination.BucketName = requestDestination_destination_BucketName;
                requestDestinationIsNull = false;
            }
            System.String requestDestination_destination_ObjectKeyPrefix = null;
            if (cmdletContext.Destination_ObjectKeyPrefix != null)
            {
                requestDestination_destination_ObjectKeyPrefix = cmdletContext.Destination_ObjectKeyPrefix;
            }
            if (requestDestination_destination_ObjectKeyPrefix != null)
            {
                request.Destination.ObjectKeyPrefix = requestDestination_destination_ObjectKeyPrefix;
                requestDestinationIsNull = false;
            }
             // determine if request.Destination should be set to null
            if (requestDestinationIsNull)
            {
                request.Destination = null;
            }
            if (cmdletContext.Simulation != null)
            {
                request.Simulation = cmdletContext.Simulation;
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
        
        private Amazon.SimSpaceWeaver.Model.CreateSnapshotResponse CallAWSServiceOperation(IAmazonSimSpaceWeaver client, Amazon.SimSpaceWeaver.Model.CreateSnapshotRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS SimSpace Weaver", "CreateSnapshot");
            try
            {
                #if DESKTOP
                return client.CreateSnapshot(request);
                #elif CORECLR
                return client.CreateSnapshotAsync(request).GetAwaiter().GetResult();
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
            public System.String Destination_BucketName { get; set; }
            public System.String Destination_ObjectKeyPrefix { get; set; }
            public System.String Simulation { get; set; }
            public System.Func<Amazon.SimSpaceWeaver.Model.CreateSnapshotResponse, NewSSWSnapshotCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
