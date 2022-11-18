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
using Amazon.IoTRoboRunner;
using Amazon.IoTRoboRunner.Model;

namespace Amazon.PowerShell.Cmdlets.IOTRR
{
    /// <summary>
    /// Grants permission to update a worker
    /// </summary>
    [Cmdlet("Update", "IOTRRWorker", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoTRoboRunner.Model.UpdateWorkerResponse")]
    [AWSCmdlet("Calls the AWS IoT RoboRunner UpdateWorker API operation.", Operation = new[] {"UpdateWorker"}, SelectReturnType = typeof(Amazon.IoTRoboRunner.Model.UpdateWorkerResponse))]
    [AWSCmdletOutput("Amazon.IoTRoboRunner.Model.UpdateWorkerResponse",
        "This cmdlet returns an Amazon.IoTRoboRunner.Model.UpdateWorkerResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateIOTRRWorkerCmdlet : AmazonIoTRoboRunnerClientCmdlet, IExecutor
    {
        
        #region Parameter AdditionalFixedProperty
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AdditionalFixedProperties")]
        public System.String AdditionalFixedProperty { get; set; }
        #endregion
        
        #region Parameter AdditionalTransientProperty
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AdditionalTransientProperties")]
        public System.String AdditionalTransientProperty { get; set; }
        #endregion
        
        #region Parameter Orientation_Degree
        /// <summary>
        /// <para>
        /// <para>Degrees, limited on [0, 360)</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Orientation_Degrees")]
        public System.Double? Orientation_Degree { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        public System.String Id { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter VendorProperties_VendorAdditionalFixedProperty
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VendorProperties_VendorAdditionalFixedProperties")]
        public System.String VendorProperties_VendorAdditionalFixedProperty { get; set; }
        #endregion
        
        #region Parameter VendorProperties_VendorAdditionalTransientProperty
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VendorProperties_VendorAdditionalTransientProperties")]
        public System.String VendorProperties_VendorAdditionalTransientProperty { get; set; }
        #endregion
        
        #region Parameter VendorProperties_VendorWorkerId
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VendorProperties_VendorWorkerId { get; set; }
        #endregion
        
        #region Parameter VendorProperties_VendorWorkerIpAddress
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VendorProperties_VendorWorkerIpAddress { get; set; }
        #endregion
        
        #region Parameter CartesianCoordinates_X
        /// <summary>
        /// <para>
        /// <para>X coordinate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Position_CartesianCoordinates_X")]
        public System.Double? CartesianCoordinates_X { get; set; }
        #endregion
        
        #region Parameter CartesianCoordinates_Y
        /// <summary>
        /// <para>
        /// <para>Y coordinate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Position_CartesianCoordinates_Y")]
        public System.Double? CartesianCoordinates_Y { get; set; }
        #endregion
        
        #region Parameter CartesianCoordinates_Z
        /// <summary>
        /// <para>
        /// <para>Z coordinate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Position_CartesianCoordinates_Z")]
        public System.Double? CartesianCoordinates_Z { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTRoboRunner.Model.UpdateWorkerResponse).
        /// Specifying the name of a property of type Amazon.IoTRoboRunner.Model.UpdateWorkerResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Id parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Id' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Id' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Id), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-IOTRRWorker (UpdateWorker)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTRoboRunner.Model.UpdateWorkerResponse, UpdateIOTRRWorkerCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Id;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AdditionalFixedProperty = this.AdditionalFixedProperty;
            context.AdditionalTransientProperty = this.AdditionalTransientProperty;
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            context.Orientation_Degree = this.Orientation_Degree;
            context.CartesianCoordinates_X = this.CartesianCoordinates_X;
            context.CartesianCoordinates_Y = this.CartesianCoordinates_Y;
            context.CartesianCoordinates_Z = this.CartesianCoordinates_Z;
            context.VendorProperties_VendorAdditionalFixedProperty = this.VendorProperties_VendorAdditionalFixedProperty;
            context.VendorProperties_VendorAdditionalTransientProperty = this.VendorProperties_VendorAdditionalTransientProperty;
            context.VendorProperties_VendorWorkerId = this.VendorProperties_VendorWorkerId;
            context.VendorProperties_VendorWorkerIpAddress = this.VendorProperties_VendorWorkerIpAddress;
            
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
            var request = new Amazon.IoTRoboRunner.Model.UpdateWorkerRequest();
            
            if (cmdletContext.AdditionalFixedProperty != null)
            {
                request.AdditionalFixedProperties = cmdletContext.AdditionalFixedProperty;
            }
            if (cmdletContext.AdditionalTransientProperty != null)
            {
                request.AdditionalTransientProperties = cmdletContext.AdditionalTransientProperty;
            }
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate Orientation
            var requestOrientationIsNull = true;
            request.Orientation = new Amazon.IoTRoboRunner.Model.Orientation();
            System.Double? requestOrientation_orientation_Degree = null;
            if (cmdletContext.Orientation_Degree != null)
            {
                requestOrientation_orientation_Degree = cmdletContext.Orientation_Degree.Value;
            }
            if (requestOrientation_orientation_Degree != null)
            {
                request.Orientation.Degrees = requestOrientation_orientation_Degree.Value;
                requestOrientationIsNull = false;
            }
             // determine if request.Orientation should be set to null
            if (requestOrientationIsNull)
            {
                request.Orientation = null;
            }
            
             // populate Position
            var requestPositionIsNull = true;
            request.Position = new Amazon.IoTRoboRunner.Model.PositionCoordinates();
            Amazon.IoTRoboRunner.Model.CartesianCoordinates requestPosition_position_CartesianCoordinates = null;
            
             // populate CartesianCoordinates
            var requestPosition_position_CartesianCoordinatesIsNull = true;
            requestPosition_position_CartesianCoordinates = new Amazon.IoTRoboRunner.Model.CartesianCoordinates();
            System.Double? requestPosition_position_CartesianCoordinates_cartesianCoordinates_X = null;
            if (cmdletContext.CartesianCoordinates_X != null)
            {
                requestPosition_position_CartesianCoordinates_cartesianCoordinates_X = cmdletContext.CartesianCoordinates_X.Value;
            }
            if (requestPosition_position_CartesianCoordinates_cartesianCoordinates_X != null)
            {
                requestPosition_position_CartesianCoordinates.X = requestPosition_position_CartesianCoordinates_cartesianCoordinates_X.Value;
                requestPosition_position_CartesianCoordinatesIsNull = false;
            }
            System.Double? requestPosition_position_CartesianCoordinates_cartesianCoordinates_Y = null;
            if (cmdletContext.CartesianCoordinates_Y != null)
            {
                requestPosition_position_CartesianCoordinates_cartesianCoordinates_Y = cmdletContext.CartesianCoordinates_Y.Value;
            }
            if (requestPosition_position_CartesianCoordinates_cartesianCoordinates_Y != null)
            {
                requestPosition_position_CartesianCoordinates.Y = requestPosition_position_CartesianCoordinates_cartesianCoordinates_Y.Value;
                requestPosition_position_CartesianCoordinatesIsNull = false;
            }
            System.Double? requestPosition_position_CartesianCoordinates_cartesianCoordinates_Z = null;
            if (cmdletContext.CartesianCoordinates_Z != null)
            {
                requestPosition_position_CartesianCoordinates_cartesianCoordinates_Z = cmdletContext.CartesianCoordinates_Z.Value;
            }
            if (requestPosition_position_CartesianCoordinates_cartesianCoordinates_Z != null)
            {
                requestPosition_position_CartesianCoordinates.Z = requestPosition_position_CartesianCoordinates_cartesianCoordinates_Z.Value;
                requestPosition_position_CartesianCoordinatesIsNull = false;
            }
             // determine if requestPosition_position_CartesianCoordinates should be set to null
            if (requestPosition_position_CartesianCoordinatesIsNull)
            {
                requestPosition_position_CartesianCoordinates = null;
            }
            if (requestPosition_position_CartesianCoordinates != null)
            {
                request.Position.CartesianCoordinates = requestPosition_position_CartesianCoordinates;
                requestPositionIsNull = false;
            }
             // determine if request.Position should be set to null
            if (requestPositionIsNull)
            {
                request.Position = null;
            }
            
             // populate VendorProperties
            var requestVendorPropertiesIsNull = true;
            request.VendorProperties = new Amazon.IoTRoboRunner.Model.VendorProperties();
            System.String requestVendorProperties_vendorProperties_VendorAdditionalFixedProperty = null;
            if (cmdletContext.VendorProperties_VendorAdditionalFixedProperty != null)
            {
                requestVendorProperties_vendorProperties_VendorAdditionalFixedProperty = cmdletContext.VendorProperties_VendorAdditionalFixedProperty;
            }
            if (requestVendorProperties_vendorProperties_VendorAdditionalFixedProperty != null)
            {
                request.VendorProperties.VendorAdditionalFixedProperties = requestVendorProperties_vendorProperties_VendorAdditionalFixedProperty;
                requestVendorPropertiesIsNull = false;
            }
            System.String requestVendorProperties_vendorProperties_VendorAdditionalTransientProperty = null;
            if (cmdletContext.VendorProperties_VendorAdditionalTransientProperty != null)
            {
                requestVendorProperties_vendorProperties_VendorAdditionalTransientProperty = cmdletContext.VendorProperties_VendorAdditionalTransientProperty;
            }
            if (requestVendorProperties_vendorProperties_VendorAdditionalTransientProperty != null)
            {
                request.VendorProperties.VendorAdditionalTransientProperties = requestVendorProperties_vendorProperties_VendorAdditionalTransientProperty;
                requestVendorPropertiesIsNull = false;
            }
            System.String requestVendorProperties_vendorProperties_VendorWorkerId = null;
            if (cmdletContext.VendorProperties_VendorWorkerId != null)
            {
                requestVendorProperties_vendorProperties_VendorWorkerId = cmdletContext.VendorProperties_VendorWorkerId;
            }
            if (requestVendorProperties_vendorProperties_VendorWorkerId != null)
            {
                request.VendorProperties.VendorWorkerId = requestVendorProperties_vendorProperties_VendorWorkerId;
                requestVendorPropertiesIsNull = false;
            }
            System.String requestVendorProperties_vendorProperties_VendorWorkerIpAddress = null;
            if (cmdletContext.VendorProperties_VendorWorkerIpAddress != null)
            {
                requestVendorProperties_vendorProperties_VendorWorkerIpAddress = cmdletContext.VendorProperties_VendorWorkerIpAddress;
            }
            if (requestVendorProperties_vendorProperties_VendorWorkerIpAddress != null)
            {
                request.VendorProperties.VendorWorkerIpAddress = requestVendorProperties_vendorProperties_VendorWorkerIpAddress;
                requestVendorPropertiesIsNull = false;
            }
             // determine if request.VendorProperties should be set to null
            if (requestVendorPropertiesIsNull)
            {
                request.VendorProperties = null;
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
        
        private Amazon.IoTRoboRunner.Model.UpdateWorkerResponse CallAWSServiceOperation(IAmazonIoTRoboRunner client, Amazon.IoTRoboRunner.Model.UpdateWorkerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT RoboRunner", "UpdateWorker");
            try
            {
                #if DESKTOP
                return client.UpdateWorker(request);
                #elif CORECLR
                return client.UpdateWorkerAsync(request).GetAwaiter().GetResult();
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
            public System.String AdditionalFixedProperty { get; set; }
            public System.String AdditionalTransientProperty { get; set; }
            public System.String Id { get; set; }
            public System.String Name { get; set; }
            public System.Double? Orientation_Degree { get; set; }
            public System.Double? CartesianCoordinates_X { get; set; }
            public System.Double? CartesianCoordinates_Y { get; set; }
            public System.Double? CartesianCoordinates_Z { get; set; }
            public System.String VendorProperties_VendorAdditionalFixedProperty { get; set; }
            public System.String VendorProperties_VendorAdditionalTransientProperty { get; set; }
            public System.String VendorProperties_VendorWorkerId { get; set; }
            public System.String VendorProperties_VendorWorkerIpAddress { get; set; }
            public System.Func<Amazon.IoTRoboRunner.Model.UpdateWorkerResponse, UpdateIOTRRWorkerCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
