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
using Amazon.RoboMaker;
using Amazon.RoboMaker.Model;

namespace Amazon.PowerShell.Cmdlets.ROBO
{
    /// <summary>
    /// <important><para>
    /// End of support notice: On September 10, 2025, Amazon Web Services will discontinue
    /// support for Amazon Web Services RoboMaker. After September 10, 2025, you will no longer
    /// be able to access the Amazon Web Services RoboMaker console or Amazon Web Services
    /// RoboMaker resources. For more information on transitioning to Batch to help run containerized
    /// simulations, visit <a href="https://aws.amazon.com/blogs/hpc/run-simulations-using-multiple-containers-in-a-single-aws-batch-job/">https://aws.amazon.com/blogs/hpc/run-simulations-using-multiple-containers-in-a-single-aws-batch-job/</a>.
    /// 
    /// </para></important><para>
    /// Creates worlds using the specified template.
    /// </para>
    /// </summary>
    [Cmdlet("New", "ROBOWorldGenerationJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RoboMaker.Model.CreateWorldGenerationJobResponse")]
    [AWSCmdlet("Calls the AWS RoboMaker CreateWorldGenerationJob API operation.", Operation = new[] {"CreateWorldGenerationJob"}, SelectReturnType = typeof(Amazon.RoboMaker.Model.CreateWorldGenerationJobResponse))]
    [AWSCmdletOutput("Amazon.RoboMaker.Model.CreateWorldGenerationJobResponse",
        "This cmdlet returns an Amazon.RoboMaker.Model.CreateWorldGenerationJobResponse object containing multiple properties."
    )]
    public partial class NewROBOWorldGenerationJobCmdlet : AmazonRoboMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier that you provide to ensure the idempotency of the
        /// request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter WorldCount_FloorplanCount
        /// <summary>
        /// <para>
        /// <para>The number of unique floorplans.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? WorldCount_FloorplanCount { get; set; }
        #endregion
        
        #region Parameter WorldCount_InteriorCountPerFloorplan
        /// <summary>
        /// <para>
        /// <para>The number of unique interiors per floorplan.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? WorldCount_InteriorCountPerFloorplan { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A map that contains tag keys and tag values that are attached to the world generator
        /// job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Template
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (arn) of the world template describing the worlds you want
        /// to create.</para>
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
        public System.String Template { get; set; }
        #endregion
        
        #region Parameter WorldTag
        /// <summary>
        /// <para>
        /// <para>A map that contains tag keys and tag values that are attached to the generated worlds.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WorldTags")]
        public System.Collections.Hashtable WorldTag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RoboMaker.Model.CreateWorldGenerationJobResponse).
        /// Specifying the name of a property of type Amazon.RoboMaker.Model.CreateWorldGenerationJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Template parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Template' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Template' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Template), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ROBOWorldGenerationJob (CreateWorldGenerationJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RoboMaker.Model.CreateWorldGenerationJobResponse, NewROBOWorldGenerationJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Template;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientRequestToken = this.ClientRequestToken;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            context.Template = this.Template;
            #if MODULAR
            if (this.Template == null && ParameterWasBound(nameof(this.Template)))
            {
                WriteWarning("You are passing $null as a value for parameter Template which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.WorldCount_FloorplanCount = this.WorldCount_FloorplanCount;
            context.WorldCount_InteriorCountPerFloorplan = this.WorldCount_InteriorCountPerFloorplan;
            if (this.WorldTag != null)
            {
                context.WorldTag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.WorldTag.Keys)
                {
                    context.WorldTag.Add((String)hashKey, (System.String)(this.WorldTag[hashKey]));
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
            var request = new Amazon.RoboMaker.Model.CreateWorldGenerationJobRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.Template != null)
            {
                request.Template = cmdletContext.Template;
            }
            
             // populate WorldCount
            var requestWorldCountIsNull = true;
            request.WorldCount = new Amazon.RoboMaker.Model.WorldCount();
            System.Int32? requestWorldCount_worldCount_FloorplanCount = null;
            if (cmdletContext.WorldCount_FloorplanCount != null)
            {
                requestWorldCount_worldCount_FloorplanCount = cmdletContext.WorldCount_FloorplanCount.Value;
            }
            if (requestWorldCount_worldCount_FloorplanCount != null)
            {
                request.WorldCount.FloorplanCount = requestWorldCount_worldCount_FloorplanCount.Value;
                requestWorldCountIsNull = false;
            }
            System.Int32? requestWorldCount_worldCount_InteriorCountPerFloorplan = null;
            if (cmdletContext.WorldCount_InteriorCountPerFloorplan != null)
            {
                requestWorldCount_worldCount_InteriorCountPerFloorplan = cmdletContext.WorldCount_InteriorCountPerFloorplan.Value;
            }
            if (requestWorldCount_worldCount_InteriorCountPerFloorplan != null)
            {
                request.WorldCount.InteriorCountPerFloorplan = requestWorldCount_worldCount_InteriorCountPerFloorplan.Value;
                requestWorldCountIsNull = false;
            }
             // determine if request.WorldCount should be set to null
            if (requestWorldCountIsNull)
            {
                request.WorldCount = null;
            }
            if (cmdletContext.WorldTag != null)
            {
                request.WorldTags = cmdletContext.WorldTag;
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
        
        private Amazon.RoboMaker.Model.CreateWorldGenerationJobResponse CallAWSServiceOperation(IAmazonRoboMaker client, Amazon.RoboMaker.Model.CreateWorldGenerationJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS RoboMaker", "CreateWorldGenerationJob");
            try
            {
                #if DESKTOP
                return client.CreateWorldGenerationJob(request);
                #elif CORECLR
                return client.CreateWorldGenerationJobAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientRequestToken { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.String Template { get; set; }
            public System.Int32? WorldCount_FloorplanCount { get; set; }
            public System.Int32? WorldCount_InteriorCountPerFloorplan { get; set; }
            public Dictionary<System.String, System.String> WorldTag { get; set; }
            public System.Func<Amazon.RoboMaker.Model.CreateWorldGenerationJobResponse, NewROBOWorldGenerationJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
